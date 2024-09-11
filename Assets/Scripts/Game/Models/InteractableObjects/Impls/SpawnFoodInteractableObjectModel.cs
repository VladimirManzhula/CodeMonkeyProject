using Game.Views.InteractableObjects;

namespace Game.Models.InteractableObjects.Impls
{
    public class SpawnFoodInteractableObjectModel : AInteractableObjectModel
    {
        public SpawnFoodInteractableObjectModel(
            IInteractableObjectView view
        ) : base(view)
        {
        }
    }
}