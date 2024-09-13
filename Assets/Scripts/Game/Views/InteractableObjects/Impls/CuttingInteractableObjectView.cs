using Game.Components;
using Game.Models.Abstract;
using Game.Services.InteractObjects;
using Game.Services.WorldCanvasLookAtCamera;
using UnityEngine;

namespace Game.Views.InteractableObjects.Impls
{
    public class CuttingInteractableObjectView : AInteractableObjectView, IWorldCanvasView
    {
        private const string CUT_TRIGGER = "Cut";
        private static readonly int _cut = Animator.StringToHash(CUT_TRIGGER);

        [SerializeField] private Transform storingTransform;
        [SerializeField] private UiProgressableComponent progressableComponent;
        [SerializeField] private Animator cuttingAnimator;
        [SerializeField] private Canvas canvas;

        public Transform StoringTransform => storingTransform;
        
        public override EInteractableType Type => EInteractableType.Cutting;

        public Canvas Canvas => canvas;

        public ELookAtCameraType LookAtCameraType => ELookAtCameraType.InverseForward;

        public void SubscribeOnProgress(IUiProgressableModel model) => progressableComponent.Subscribe(model);

        public void DisableProgressBar() => progressableComponent.DisableProgressBar();

        public override void InteractAlternative() => cuttingAnimator.SetTrigger(_cut);
    }
}