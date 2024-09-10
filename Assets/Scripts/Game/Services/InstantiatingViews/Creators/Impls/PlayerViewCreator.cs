using Game.DataHolders;
using Game.Factories.View;
using Game.Models.Players.Impls;
using Game.Views.Player;

namespace Game.Services.InstantiatingViews.Creators.Impls
{
    public class PlayerViewCreator : AViewCreator<PlayerView>
    {
        private readonly IPlayerModelDataHolder _playerModelDataHolder;

        protected override EGameViewType Type => EGameViewType.Player;

        public PlayerViewCreator(
            IGameViewFactory gameViewFactory,
            IPlayerModelDataHolder playerModelDataHolder
        ) : base(gameViewFactory)
        {
            _playerModelDataHolder = playerModelDataHolder;
        }

        protected override void OnViewCreated(PlayerView view)
        {
            var playerModel = new PlayerModel(
                view.transform,
                view.PickingTransform
            );
            _playerModelDataHolder.SetModel(playerModel);
            view.SubscribeOnVelocityChanged(playerModel);
        }
    }
}