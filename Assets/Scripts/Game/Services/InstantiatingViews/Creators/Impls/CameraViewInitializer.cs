using Game.DataHolders;
using Game.Factories;
using Game.Models.Cameras.Impls;
using Game.Views.Camera;

namespace Game.Services.InstantiatingViews.Creators.Impls
{
    public class CameraViewInitializer : AViewInitializer<CameraView>
    {
        private readonly ICameraModelDataHolder _cameraModelDataHolder;
        
        protected override EGameViewType Type => EGameViewType.Camera;

        public CameraViewInitializer(
            IGameViewFactory gameViewFactory,
            ICameraModelDataHolder cameraModelDataHolder
        ) : base(gameViewFactory)
        {
            _cameraModelDataHolder = cameraModelDataHolder;
        }

        protected override void OnViewInitializer(CameraView view)
        {
            var cameraModel = new CameraModel(view.transform);
            view.SubscribeOnPositionChanged(cameraModel);
            view.SubscribeOnRotationChanged(cameraModel);
            _cameraModelDataHolder.SetModel(cameraModel);
        }
    }
}