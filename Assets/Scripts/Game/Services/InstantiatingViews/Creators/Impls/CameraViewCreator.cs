using Game.Factories.View;
using Game.Views.Camera;

namespace Game.Services.InstantiatingViews.Creators.Impls
{
    public class CameraViewCreator : AViewCreator<CameraView>
    {
        protected override EGameViewType Type => EGameViewType.Camera;

        public CameraViewCreator(
            IGameViewFactory gameViewFactory
        ) : base(gameViewFactory)
        {
        }

        protected override void OnViewCreated(CameraView view)
        {
        }
    }
}