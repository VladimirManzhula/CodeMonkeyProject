using System;
using System.Collections.Generic;
using System.Linq;
using Databases.EndurableModels;
using Random = UnityEngine.Random;

namespace Databases.RecipeSettings.Impls
{
    public class RecipeSettingsBase : IRecipeSettingsBase
    {
        private readonly IRecipeSettingsDao _recipeSettingsDao;

        public RecipeSettingsBase(IRecipeSettingsDao recipeSettingsDao)
        {
            _recipeSettingsDao = recipeSettingsDao;
        }

        public int RecipesLimit => _recipeSettingsDao.RecipesLimit;
        public float RecipesLoadingTime => _recipeSettingsDao.RecipesLoadingTime;
        
        public bool TryGetRecipeByComponents(List<EEndurableType> components, out ERecipeType recipeType)
        {
            for (var index = 0; index < _recipeSettingsDao.Vos.Length; index++)
            {
                var vo = _recipeSettingsDao.Vos[index];
                
                if(vo.components.Count != components.Count)
                    continue;
                
                var isEqual = components.OrderBy(x => x).SequenceEqual(vo.components.OrderBy(x => x));
                
                if(!isEqual)
                    continue;

                recipeType = vo.type;
                return true;
            }

            recipeType = ERecipeType.None;
            return false;
        }

        public ERecipeType GetRandomRecipe()
        {
            var vosLength = _recipeSettingsDao.Vos.Length;
            var randomIndex = Random.Range(0, vosLength);
            return _recipeSettingsDao.Vos[randomIndex].type;
        }

        public List<EEndurableType> GetIngredients(ERecipeType recipeType)
        {
            for (var index = 0; index < _recipeSettingsDao.Vos.Length; index++)
            {
                var vo = _recipeSettingsDao.Vos[index];

                if (vo.type != recipeType)
                    continue;

                return vo.components;
            }

            throw new Exception($"{nameof(RecipeSettingsBase)} Doesn't exist settings with type : {recipeType}");
        }
    }
}