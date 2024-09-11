using Game.Models.InteractableObjects.Impls;
using Game.Views.InteractableObjects.Impls;

namespace Game.Services.InteractObjects.Impls
{
    public class DeliveryInteractableStrategy : AInteractableStrategy<DeliveryInteractableObjectView,
        DeliveryInteractableObjectModel>
    {

        public override EInteractableType Type => EInteractableType.Delivery;
        
        protected override DeliveryInteractableObjectModel GetModel(DeliveryInteractableObjectView view)
        {
            throw new System.NotImplementedException();
        }
    }
}