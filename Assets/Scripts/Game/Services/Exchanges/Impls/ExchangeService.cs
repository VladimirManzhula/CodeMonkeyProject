using Databases.Audio;
using Game.CompositeFood;
using Game.DataHolders;
using Game.Models.Abstract;
using Game.Services.DAO.Settings.Audio.Service;

namespace Game.Services.Exchanges.Impls
{
    public class ExchangeService : IExchangeService
    {
        private readonly ICompositeFoodService _compositeFoodService;
        private readonly IAudioService _audioService;
        private readonly IPlayerModelDataHolder _playerModelDataHolder;

        public ExchangeService(
            ICompositeFoodService compositeFoodService,
            IAudioService audioService,
            IPlayerModelDataHolder playerModelDataHolder
        )
        {
            _compositeFoodService = compositeFoodService;
            _audioService = audioService;
            _playerModelDataHolder = playerModelDataHolder;
        }

        public void Execute(IStorableModel player, IStorableModel interactable)
        {
            if (player.EndurableModel.Value != null)
            {
                if (interactable.EndurableModel.Value != null)
                {
                    _compositeFoodService.CreateCompositeFood(player, interactable);
                    return;
                }

                Exchange(player, interactable);
                _audioService.PlaySfx(ESoundType.DropObject, _playerModelDataHolder.PlayerPosition);
            }
            else
            {
                if (interactable.EndurableModel.Value == null)
                    return;

                Exchange(interactable, player);
                _audioService.PlaySfx(ESoundType.PickUpObject, _playerModelDataHolder.PlayerPosition);
            }
        }

        private static void Exchange(IStorableModel destination, IStorableModel source)
        {
            source.SetEndurableModel(destination.EndurableModel.Value);
            destination.ClearEndurableModel();
        }
    }
}