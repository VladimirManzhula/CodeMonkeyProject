using Game.Components;
using Game.Models.Abstract;
using Game.Services.InteractObjects;
using Game.Services.WorldCanvasLookAtCamera;
using UnityEngine;

namespace Game.Views.InteractableObjects.Impls
{
    public class FryingInteractableObjectView : AInteractableObjectView, IWorldCanvasView
    {
        [SerializeField] private Transform storingTransform;
        [SerializeField] private UiProgressableComponent progressableComponent;
        [SerializeField] private GameObject fryingVisual;
        [SerializeField] private ParticleSystem animationParticleSystem;
        [SerializeField] private Canvas canvas;

        public override EInteractableType Type => EInteractableType.Frying;

        public ELookAtCameraType LookAtCameraType => ELookAtCameraType.InverseForward;

        public Transform StoringTransform => storingTransform;

        public Canvas Canvas => canvas;

        public void PlayFryingAnimation()
        {
            fryingVisual.SetActive(true);
            animationParticleSystem.Play();
        }

        public void StopFryingAnimation()
        {
            fryingVisual.SetActive(false);
            animationParticleSystem.Stop();
        }

        public void SubscribeOnProgress(IUiProgressableModel model) => progressableComponent.Subscribe(model);

        public void DisableProgressBar() => progressableComponent.DisableProgressBar();
    }
}