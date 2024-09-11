using Databases.EndurableModels;
using Game.Services.InteractObjects;
using UnityEngine;

namespace Game.Views.InteractableObjects.Impls
{
    public class SpawnFoodInteractableObjectView : AInteractableObjectView
    {
        [SerializeField] private SpriteRenderer imageRenderer;
        [SerializeField] private EEndurableType endurableType;

        public override EInteractableType Type => EInteractableType.SpawnFood;

        public EEndurableType EndurableType => endurableType;

        public void SetSprite(Sprite sprite) => imageRenderer.sprite = sprite;
    }
}