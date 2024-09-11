using Game.Services.InteractObjects;
using UniRx.Triggers;

namespace Game.Views.InteractableObjects
{
    public interface IInteractableObjectView
    {
        EInteractableType Type { get; }
        
        ObservableCollisionTrigger CollisionTrigger { get; }
        
        void OnPlayerEnter();

        void Interact();

        void InteractAlternative();

        void OnPlayerExit();
    }
}