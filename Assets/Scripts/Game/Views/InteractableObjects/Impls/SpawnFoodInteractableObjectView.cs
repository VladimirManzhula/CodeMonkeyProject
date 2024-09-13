using Databases.EndurableModels;
using Game.Services.InteractObjects;
using UnityEngine;

namespace Game.Views.InteractableObjects.Impls
{
    public class SpawnFoodInteractableObjectView : AInteractableObjectView
    {
        private const string OPEN_CLOSE_TRIGGER = "OpenClose";
        private readonly int _openClose = Animator.StringToHash(OPEN_CLOSE_TRIGGER);
        
        [SerializeField] private SpriteRenderer imageRenderer;
        [SerializeField] private Animator openAnimator;
        [SerializeField] private EEndurableType endurableType;

        public override EInteractableType Type => EInteractableType.SpawnFood;

        public EEndurableType EndurableType => endurableType;

        public void SetSprite(Sprite sprite) => imageRenderer.sprite = sprite;
        
        public override void Interact() => openAnimator.SetTrigger(_openClose);
    }
}