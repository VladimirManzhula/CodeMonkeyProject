using Game.DataHolders;
using Game.Models.InteractableObjects.Impls;
using Game.Services.Exchanges;
using Game.Views.InteractableObjects.Impls;

namespace Game.Services.InteractObjects.Impls
{
    public class StoringInteractableStrategy : AInteractableStrategy<StoringInteractableObjectView,
        StoringInteractableObjectModel>
    {
        private readonly IPlayerModelDataHolder _playerModelDataHolder;
        private readonly IExchangeService _exchangeService;
        public override EInteractableType Type => EInteractableType.Storing;

        public StoringInteractableStrategy(
            IPlayerModelDataHolder playerModelDataHolder,
            IExchangeService exchangeService
        )
        {
            _playerModelDataHolder = playerModelDataHolder;
            _exchangeService = exchangeService;
        }

        protected override StoringInteractableObjectModel GetModel(StoringInteractableObjectView view)
        {
            var storingModel = new StoringInteractableObjectModel(view)
            {
                StoringTransform = view.StoringTransform
            };

            void GetInteractionAction()
            {
                var playerModel = _playerModelDataHolder.Model;
                _exchangeService.Execute(playerModel, storingModel);
            }

            storingModel.ExecutingAction = GetInteractionAction;
            return storingModel;
        }
    }
}