using Game.Views.InteractableObjects;
using UnityEngine;

namespace Game.Models.InteractableObjects.Impls
{
    public class CuttingInteractableObjectModel : AStorableInteractableObjectModel
    {
        public Transform StoringTransform { get; set; }
        
        public CuttingInteractableObjectModel(
            IInteractableObjectView view
        ) : base(view)
        {
        }

        protected override Transform GetStorableTransform() => StoringTransform;

        public override bool IsViewAlternativeInteractionPossible => EndurableModel.Value != null;
    }
}