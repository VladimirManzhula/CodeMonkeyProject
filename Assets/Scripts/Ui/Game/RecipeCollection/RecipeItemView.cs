using System.Collections.Generic;
using SimpleUi.Abstracts;
using TMPro;
using UnityEngine;

namespace Ui.Game.RecipeCollection
{
    public class RecipeItemView : UiView
    {
        [SerializeField] private TMP_Text recipeNameText;
        [SerializeField] private RecipeIngredientCollection ingredientCollection;

        public void SetParameters(
            string recipeName,
            List<Sprite> ingredientSprites
        )
        {
            recipeNameText.text = recipeName;

            foreach (var ingredientSprite in ingredientSprites)
            {
                var recipeIngredientItemView = ingredientCollection.Create();
                recipeIngredientItemView.SetSprite(ingredientSprite);
            }
        }
    }
}