using Core.Utils.Drawers;
using UnityEngine;

namespace Databases.RecipeSettings.Impls
{
    [CreateAssetMenu(
        menuName = "Databases/" + nameof(RecipeSettingsDao),
        fileName = nameof(RecipeSettingsDao), order = 0
    )]
    public class RecipeSettingsDao : ScriptableObject, IRecipeSettingsDao
    {
        [SerializeField] private int recipesLimit = 3;
        [SerializeField] private float recipesLoadingTime = 2f;
        
        [KeyValue("type")]
        [SerializeField] private RecipeSettingsVo[] vos;

        public int RecipesLimit => recipesLimit;
        public float RecipesLoadingTime => recipesLoadingTime;
        public RecipeSettingsVo[] Vos => vos;
    }
}