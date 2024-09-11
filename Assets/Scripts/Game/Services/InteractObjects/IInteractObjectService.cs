using Game.Models.InteractableObjects;
using Game.Views.InteractableObjects;

namespace Game.Services.InteractObjects
{
    public interface IInteractObjectService
    {
        IInteractableObjectModel[] CreateInteractableModels(IInteractableObjectView[] interactableObjectViews);
        
        void AddInteractModel(IInteractableObjectModel model);

        void Execute();

        void ExecuteAlternative();

        void RemoveInteractableModel(IInteractableObjectModel model);
    }
}