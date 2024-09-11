using Game.Models.InteractableObjects;
using Game.Views.InteractableObjects;

namespace Game.Services.InteractObjects
{
    public interface IInteractableStrategy{
        EInteractableType Type { get; }

        IInteractableObjectModel GetInteractableObjectModel(IInteractableObjectView view);
    }
}