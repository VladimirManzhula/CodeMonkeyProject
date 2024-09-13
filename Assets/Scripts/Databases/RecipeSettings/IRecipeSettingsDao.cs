namespace Databases.RecipeSettings
{
    public interface IRecipeSettingsDao
    {
        int RecipesLimit { get; }
        float RecipesLoadingTime { get; }
        RecipeSettingsVo[] Vos { get; }
    }
}