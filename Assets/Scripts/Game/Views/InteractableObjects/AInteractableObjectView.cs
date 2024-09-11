using Game.Components;
using Game.Services.InteractObjects;
using UniRx.Triggers;
using UnityEngine;

namespace Game.Views.InteractableObjects
{
    public abstract class AInteractableObjectView : MonoBehaviour, IInteractableObjectView
    {
        [SerializeField] private ObservableCollisionTrigger collisionTrigger;
        [SerializeField] private InteractableMaterialsChangeComponent interactableMaterialsChangeComponent;

        public ObservableCollisionTrigger CollisionTrigger => collisionTrigger;
        
        public abstract EInteractableType Type { get; }

        public virtual void OnPlayerEnter() => interactableMaterialsChangeComponent.SetInteractableMaterial();
        
        public virtual void Interact()
        {
        }

        public virtual void InteractAlternative()
        {
        }

        public virtual void OnPlayerExit() => interactableMaterialsChangeComponent.SetNormalMaterial();
    }
}