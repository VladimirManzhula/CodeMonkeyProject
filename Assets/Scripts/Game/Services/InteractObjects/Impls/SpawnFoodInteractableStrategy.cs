using Databases.EndurableModels;
using Game.DataHolders;
using Game.Factories;
using Game.Models.InteractableObjects.Impls;
using Game.Views.InteractableObjects.Impls;

namespace Game.Services.InteractObjects.Impls
{
    public class SpawnFoodInteractableStrategy : AInteractableStrategy<SpawnFoodInteractableObjectView,
        SpawnFoodInteractableObjectModel>
    {
        private readonly IPlayerModelDataHolder _playerModelDataHolder;
        private readonly IEndurableFactory _endurableFactory;
        private readonly IEndurableModelsBase _endurableModelsBase;

        public override EInteractableType Type => EInteractableType.SpawnFood;

        public SpawnFoodInteractableStrategy(
            IPlayerModelDataHolder playerModelDataHolder,
            IEndurableFactory endurableFactory,
            IEndurableModelsBase endurableModelsBase
        )
        {
            _playerModelDataHolder = playerModelDataHolder;
            _endurableFactory = endurableFactory;
            _endurableModelsBase = endurableModelsBase;
        }

        protected override SpawnFoodInteractableObjectModel GetModel(SpawnFoodInteractableObjectView view)
        {
            var model = new SpawnFoodInteractableObjectModel(view);

            void GetInteractionAction()
            {
                var playerModel = _playerModelDataHolder.Model;
                
                if(playerModel.EndurableModel.Value != null)
                    return;
                
                var endurableType = view.EndurableType;
                var endurableModel = _endurableFactory.CreateSimple(endurableType);
                playerModel.SetEndurableModel(endurableModel);
            }

            model.ExecutingAction = GetInteractionAction;
            
            return model;
        }

        protected override void OnViewInitialize(SpawnFoodInteractableObjectView view)
        {
            var foodType = view.EndurableType;
            var sprite = _endurableModelsBase.GetSpriteByType(foodType);
            view.SetSprite(sprite);
        }
    }
}