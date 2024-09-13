using SimpleUi.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Game.RecipeCollection
{
    public class RecipeIngredientItemView : UiView
    {
        [SerializeField] private Image image;

        public void SetSprite(Sprite sprite) => image.sprite = sprite;
    }
}