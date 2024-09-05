using Game.Factories.View;
using Game.Views.Levels.Impls;

namespace Game.Services.InstantiatingViews.Creators.Impls
{
    public class LevelViewCreator : AViewCreator<LevelView>
    {
        protected override EGameViewType Type => EGameViewType.Level;

        public LevelViewCreator(
            IGameViewFactory gameViewFactory
        ) : base(gameViewFactory)
        {
        }

        protected override void OnViewCreated(LevelView view)
        {
        }
    }
}