using Game.Models.InteractableObjects;

namespace Game.Models.Levels.Impls
{
    public class LevelModel : ILevelModel
    {
        public IInteractableObjectModel[] InteractableObjectModels { get; }
        
        public LevelModel(
            IInteractableObjectModel[] interactableObjectModels
        )
        {
            InteractableObjectModels = interactableObjectModels;
        }
    }
}