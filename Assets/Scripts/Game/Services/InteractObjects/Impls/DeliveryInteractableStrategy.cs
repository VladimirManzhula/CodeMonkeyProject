using Databases.Audio;
using Game.DataHolders;
using Game.Models.InteractableObjects.Impls;
using Game.Services.DAO.Settings.Audio.Service;
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
        private readonly IAudioService _audioService;

        public override EInteractableType Type => EInteractableType.Delivery;

        public DeliveryInteractableStrategy(
            IPlayerModelDataHolder playerModelDataHolder,
            IRecipeService recipeService,
            IAudioService audioService
        )
        {
            _playerModelDataHolder = playerModelDataHolder;
            _recipeService = recipeService;
            _audioService = audioService;
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
                    _audioService.PlaySfx(ESoundType.DeliveryFail, view.transform.position);
                    return;
                }
                
                Debug.Log(recipeType);
                playerEndurableModel.IsDestroyed.Value = true;
                playerModel.ClearEndurableModel();
                _audioService.PlaySfx(ESoundType.DeliverySuccess, view.transform.position);
            }

            model.ExecutingAction = GetInteractionAction;
            return model;
        }
    }
}