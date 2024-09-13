using System;
using System.Linq;
using Databases.RecipeSettings;
using Game.Models.Endurables;
using UniRx;
using Zenject;

namespace Game.Services.Recipes.Impls
{
    public class RecipeService : IRecipeService, IInitializable, IDisposable
    {
        private readonly IRecipeSettingsBase _recipeSettingsBase;

        private readonly ReactiveCollection<ERecipeType> _recipes = new();
        public IReactiveCollection<ERecipeType> Recipes => _recipes;

        private IDisposable _intervalDisposable = Disposable.Empty;

        public RecipeService(
            IRecipeSettingsBase recipeSettingsBase
        )
        {
            _recipeSettingsBase = recipeSettingsBase;
        }

        public void Initialize()
        {
            var recipesLoadingTime = _recipeSettingsBase.RecipesLoadingTime;
            _intervalDisposable = Observable.Interval(TimeSpan.FromSeconds(recipesLoadingTime))
                .Subscribe(OnInterval);
        }

        public void Dispose() => _intervalDisposable.Dispose();

        public bool TryRemoveRecipe(IEndurableModel model, out ERecipeType recipeType)
        {
            var ingredients = model.SubTypes.ToList();

            if (!_recipeSettingsBase.TryGetRecipeByComponents(ingredients, out recipeType))
                return false;

            for (var index = 0; index < _recipes.Count; index++)
            {
                var recipe = _recipes[index];

                if (recipe != recipeType)
                    continue;
                
                _recipes.RemoveAt(index);
                return true;
            }

            return false;
        }

        private void OnInterval(long l)
        {
            var recipesCount = _recipes.Count;
            var recipesLimit = _recipeSettingsBase.RecipesLimit;

            if (recipesCount == recipesLimit)
                return;

            var randomRecipe = _recipeSettingsBase.GetRandomRecipe();
            _recipes.Add(randomRecipe);
        }
    }
}