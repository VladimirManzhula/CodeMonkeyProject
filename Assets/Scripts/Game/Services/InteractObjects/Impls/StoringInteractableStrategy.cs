using Game.Models.InteractableObjects.Impls;
using Game.Views.InteractableObjects.Impls;

namespace Game.Services.InteractObjects.Impls
{
    public class StoringInteractableStrategy : AInteractableStrategy<StoringInteractableObjectView,
        StoringInteractableObjectModel>
    {
        public override EInteractableType Type => EInteractableType.Storing;
        protected override StoringInteractableObjectModel GetModel(StoringInteractableObjectView view)
        {
            throw new System.NotImplementedException();
        }
    }
}