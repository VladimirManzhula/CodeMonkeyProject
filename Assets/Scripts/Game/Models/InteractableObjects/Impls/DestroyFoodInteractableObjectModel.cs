using Game.Views.InteractableObjects;

namespace Game.Models.InteractableObjects.Impls
{
    public class DestroyFoodInteractableObjectModel : AInteractableObjectModel
    {
        public DestroyFoodInteractableObjectModel(
            IInteractableObjectView view
        ) : base(view)
        {
        }
    }
}