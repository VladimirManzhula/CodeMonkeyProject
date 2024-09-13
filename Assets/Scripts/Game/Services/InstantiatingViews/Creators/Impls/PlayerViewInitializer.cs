using Game.DataHolders;
using Game.Factories;
using Game.Models.Players.Impls;
using Game.Views.Player;

namespace Game.Services.InstantiatingViews.Creators.Impls
{
    public class PlayerViewInitializer : AViewInitializer<PlayerView>
    {
        private readonly IPlayerModelDataHolder _playerModelDataHolder;

        protected override EGameViewType Type => EGameViewType.Player;

        public PlayerViewInitializer(
            IGameViewFactory gameViewFactory,
            IPlayerModelDataHolder playerModelDataHolder
        ) : base(gameViewFactory)
        {
            _playerModelDataHolder = playerModelDataHolder;
        }

        protected override void OnViewInitializer(PlayerView view)
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