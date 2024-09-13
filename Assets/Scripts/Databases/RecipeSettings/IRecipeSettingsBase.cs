using System.Collections.Generic;
using Databases.EndurableModels;

namespace Databases.RecipeSettings
{
    public interface IRecipeSettingsBase
    {
        int RecipesLimit { get; }
        
        float RecipesLoadingTime { get; }
        
        bool TryGetRecipeByComponents(List<EEndurableType> components, out ERecipeType recipeType);

        ERecipeType GetRandomRecipe();

        List<EEndurableType> GetIngredients(ERecipeType recipeType);
    }
}