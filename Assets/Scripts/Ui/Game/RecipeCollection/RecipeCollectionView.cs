using System.Collections.Generic;
using SimpleUi.Abstracts;
using UnityEngine;

namespace Ui.Game.RecipeCollection
{
    public class RecipeCollectionView : UiView
    {
        [SerializeField] private RecipeUiCollection recipeCollection;

        public void AddRecipe(string recipeName, List<Sprite> ingredientSprites)
        {
            var recipeItemView = recipeCollection.Create();
            recipeItemView.SetParameters(recipeName, ingredientSprites);
        }

        public void RemoveRecipe(int index) => recipeCollection.RemoveAt(index);
    }
}