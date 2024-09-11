using Game.DataHolders;
using Game.Models.InteractableObjects.Impls;
using Game.Views.InteractableObjects.Impls;

namespace Game.Services.InteractObjects.Impls
{
    public class DestroyFoodIntractableStrategy : AInteractableStrategy<DestroyFoodInteractableObjectView,
        DestroyFoodInteractableObjectModel>
    {
        private readonly IPlayerModelDataHolder _playerModelDataHolder;
        public override EInteractableType Type => EInteractableType.DestroyFood;

        public DestroyFoodIntractableStrategy(
            IPlayerModelDataHolder playerModelDataHolder
        )
        {
            _playerModelDataHolder = playerModelDataHolder;
        }

        protected override DestroyFoodInteractableObjectModel GetModel(
            DestroyFoodInteractableObjectView view
        )
        {
            var model = new DestroyFoodInteractableObjectModel(view);

            void GetInteractionAction()
            {
                var playerModel = _playerModelDataHolder.Model;
                var playerEndurableModel = playerModel.EndurableModel.Value;

                if(playerEndurableModel == null)
                    return;
                
                playerModel.ClearEndurableModel();
                playerEndurableModel.IsDestroyed.Value = true;
            }

            model.ExecutingAction = GetInteractionAction;
            return model;
        }
    }
}