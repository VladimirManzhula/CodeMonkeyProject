using Game.Views.InteractableObjects;
using UnityEngine;

namespace Game.Models.InteractableObjects.Impls
{
    public class StoringInteractableObjectModel : AStorableInteractableObjectModel
    {
        public Transform StoringTransform { get; set; }
        
        public StoringInteractableObjectModel(
            IInteractableObjectView view 
        ) : base(view)
        {
        }

        protected override Transform GetStorableTransform() => StoringTransform;
    }
}