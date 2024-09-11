using Game.Views.InteractableObjects;

namespace Game.Views.Levels
{
    public interface ILevelView
    {
        IInteractableObjectView[] InteractableObjectViews { get; }
    }
}