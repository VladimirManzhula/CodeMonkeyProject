using System;
using System.Collections.Generic;
using Databases.EndurableModels;
using Databases.RecipeSettings;
using Game.Services.Recipes;
using SimpleUi.Abstracts;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ui.Game.RecipeCollection
{
    public class RecipeCollectionController : UiController<RecipeCollectionView>, IInitializable, IDisposable
    {
        private readonly IRecipeService _recipeService;
        private readonly IRecipeSettingsBase _recipeSettingsBase;
        private readonly IEndurableModelsBase _endurableModelsBase;

        private readonly CompositeDisposable _disposables = new();

        public RecipeCollectionController(
            IRecipeService recipeService,
            IRecipeSettingsBase recipeSettingsBase,
            IEndurableModelsBase endurableModelsBase
        )
        {
            _recipeService = recipeService;
            _recipeSettingsBase = recipeSettingsBase;
            _endurableModelsBase = endurableModelsBase;
        }

        public void Initialize()
        {
            _recipeService.Recipes.ObserveAdd()
                .Subscribe(OnRecipeAdd)
                .AddTo(_disposables);

            _recipeService.Recipes.ObserveRemove()
                .Subscribe(OnRecipeRemove)
                .AddTo(_disposables);
        }

        public void Dispose() => _disposables.Dispose();

        private void OnRecipeAdd(CollectionAddEvent<ERecipeType> recipe)
        {
            var ingredients = _recipeSettingsBase.GetIngredients(recipe.Value);
            var ingredientSprites = new List<Sprite>(ingredients.Count);

            foreach (var ingredient in ingredients)
            {
                var spriteByType = _endurableModelsBase.GetSpriteByType(ingredient);
                ingredientSprites.Add(spriteByType);
            }

            View.AddRecipe(recipe.Value.ToString(), ingredientSprites);
        }
        
        private void OnRecipeRemove(CollectionRemoveEvent<ERecipeType> recipe) => View.RemoveRecipe(recipe.Index);
    }
}