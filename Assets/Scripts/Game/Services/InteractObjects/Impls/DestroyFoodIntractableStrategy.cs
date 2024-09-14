using Databases.Audio;
using Game.DataHolders;
using Game.Models.InteractableObjects.Impls;
using Game.Services.Audio.Service;
using Game.Views.InteractableObjects.Impls;

namespace Game.Services.InteractObjects.Impls
{
    public class DestroyFoodIntractableStrategy : AInteractableStrategy<DestroyFoodInteractableObjectView,
        DestroyFoodInteractableObjectModel>
    {
        private readonly IPlayerModelDataHolder _playerModelDataHolder;
        private readonly IAudioService _audioService;
        public override EInteractableType Type => EInteractableType.DestroyFood;

        public DestroyFoodIntractableStrategy(
            IPlayerModelDataHolder playerModelDataHolder,
            IAudioService audioService
        )
        {
            _playerModelDataHolder = playerModelDataHolder;
            _audioService = audioService;
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
                _audioService.PlaySfx(ESoundType.Trash, view.transform.position);
            }

            model.ExecutingAction = GetInteractionAction;
            return model;
        }
    }
}