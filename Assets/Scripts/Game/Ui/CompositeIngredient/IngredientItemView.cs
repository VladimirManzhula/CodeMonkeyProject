using SimpleUi.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Ui.CompositeIngredient
{
    public class IngredientItemView : UiView
    {
        [SerializeField] private Image ingredientImage;

        public void SetSprite(Sprite sprite) => ingredientImage.sprite = sprite;
    }
}