using Game.Factories.View;
using Game.Views.Player;

namespace Game.Services.InstantiatingViews.Creators.Impls
{
    public class PlayerViewCreator : AViewCreator<PlayerView>
    {
        protected override EGameViewType Type => EGameViewType.Player;

        public PlayerViewCreator(
            IGameViewFactory gameViewFactory
        ) : base(gameViewFactory)
        {
        }

        protected override void OnViewCreated(PlayerView view)
        {
        }
    }
}