using Game.DataHolders;
using Game.Factories.View;
using Game.Models.Cameras.Impls;
using Game.Views.Camera;

namespace Game.Services.InstantiatingViews.Creators.Impls
{
    public class CameraViewCreator : AViewCreator<CameraView>
    {
        private readonly ICameraModelDataHolder _cameraModelDataHolder;
        
        protected override EGameViewType Type => EGameViewType.Camera;

        public CameraViewCreator(
            IGameViewFactory gameViewFactory,
            ICameraModelDataHolder cameraModelDataHolder
        ) : base(gameViewFactory)
        {
            _cameraModelDataHolder = cameraModelDataHolder;
        }

        protected override void OnViewCreated(CameraView view)
        {
            var cameraModel = new CameraModel(view.transform);
            view.SubscribeOnPositionChanged(cameraModel);
            view.SubscribeOnRotationChanged(cameraModel);
            _cameraModelDataHolder.SetModel(cameraModel);
        }
    }
}