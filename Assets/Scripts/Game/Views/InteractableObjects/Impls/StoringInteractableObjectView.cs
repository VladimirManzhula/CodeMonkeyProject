using Game.Services.InteractObjects;
using UnityEngine;

namespace Game.Views.InteractableObjects.Impls
{
    public class StoringInteractableObjectView : AInteractableObjectView
    {
        [SerializeField] private Transform storingTransform;

        public Transform StoringTransform => storingTransform;

        public override EInteractableType Type => EInteractableType.Storing;
    }
}