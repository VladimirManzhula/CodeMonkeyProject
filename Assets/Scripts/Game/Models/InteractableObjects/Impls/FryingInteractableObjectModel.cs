using Game.Views.InteractableObjects;
using UnityEngine;

namespace Game.Models.InteractableObjects.Impls
{
    public class FryingInteractableObjectModel : AStorableInteractableObjectModel
    {
        public Transform StoringTransform { get; set; }
        
        public FryingInteractableObjectModel(
            IInteractableObjectView view
        ) : base(view)
        {
        }

        protected override Transform GetStorableTransform() => StoringTransform;
    }
}