using Game.Models.InteractableObjects;

namespace Game.Models.Levels
{
    public interface ILevelModel
    {
        IInteractableObjectModel[] InteractableObjectModels { get; }
    }
}