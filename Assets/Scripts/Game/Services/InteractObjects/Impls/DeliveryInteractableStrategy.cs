using Game.DataHolders;
using Game.Models.InteractableObjects.Impls;
using Game.Services.Recipes;
using Game.Views.InteractableObjects.Impls;
using UnityEngine;

namespace Game.Services.InteractObjects.Impls
{
    public class DeliveryInteractableStrategy : AInteractableStrategy<DeliveryInteractableObjectView,
        DeliveryInteractableObjectModel>
    {
        private readonly IPlayerModelDataHolder _playerModelDataHolder;
        private readonly IRecipeService _recipeService;

        public override EInteractableType Type => EInteractableType.Delivery;

        public DeliveryInteractableStrategy(
            IPlayerModelDataHolder playerModelDataHolder,
            IRecipeService recipeService
        )
        {
            _playerModelDataHolder = playerModelDataHolder;
            _recipeService = recipeService;
        }

        protected override DeliveryInteractableObjectModel GetModel(DeliveryInteractableObjectView view)
        {
            var model = new DeliveryInteractableObjectModel(view);

            void GetInteractionAction()
            {
                var playerModel = _playerModelDataHolder.Model;
                var playerEndurableModel = playerModel.EndurableModel.Value;

                if (playerEndurableModel == null)
                    return;

                if (!_recipeService.TryRemoveRecipe(playerEndurableModel, out var recipeType))
                {
                    return;
                }
                
                Debug.Log(recipeType);
                playerEndurableModel.IsDestroyed.Value = true;
                playerModel.ClearEndurableModel();
            }

            model.ExecutingAction = GetInteractionAction;
            return model;
        }
    }
}