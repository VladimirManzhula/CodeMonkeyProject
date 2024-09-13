using Databases.RecipeSettings;
using Game.Models.Endurables;
using UniRx;

namespace Game.Services.Recipes
{
    public interface IRecipeService
    {
        IReactiveCollection<ERecipeType> Recipes { get; }

        bool TryRemoveRecipe(IEndurableModel model, out ERecipeType recipeType);
    }
}