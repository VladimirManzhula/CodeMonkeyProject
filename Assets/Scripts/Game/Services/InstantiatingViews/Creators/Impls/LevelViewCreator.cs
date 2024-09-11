using Game.DataHolders;
using Game.Factories;
using Game.Models.Levels.Impls;
using Game.Services.InteractObjects;
using Game.Services.WorldCanvasLookAtCamera;
using Game.Views.InteractableObjects;
using Game.Views.Levels.Impls;

namespace Game.Services.InstantiatingViews.Creators.Impls
{
    public class LevelViewCreator : AViewCreator<LevelView>
    {
        private readonly ILevelModelDataHolder _levelModelDataHolder;
        private readonly IInteractObjectService _interactObjectService;
        private readonly IWorldCanvasLookAtCameraService _worldCanvasLookAtCameraService;

        protected override EGameViewType Type => EGameViewType.Level;

        public LevelViewCreator(
            IGameViewFactory gameViewFactory,
            ILevelModelDataHolder levelModelDataHolder,
            IInteractObjectService interactObjectService,
            IWorldCanvasLookAtCameraService worldCanvasLookAtCameraService
        ) : base(gameViewFactory)
        {
            _levelModelDataHolder = levelModelDataHolder;
            _interactObjectService = interactObjectService;
            _worldCanvasLookAtCameraService = worldCanvasLookAtCameraService;
        }

        protected override void OnViewCreated(LevelView view)
        {
            var models = _interactObjectService.CreateInteractableModels(view.InteractableObjectViews);
            var levelModel = new LevelModel(models);
            _levelModelDataHolder.SetModel(levelModel);
            
            foreach (var interactableObjectView in view.InteractableObjectViews)
            {
                if(interactableObjectView is not IWorldCanvasView worldCanvasView)
                    continue;
                
                _worldCanvasLookAtCameraService.Add(worldCanvasView);
            }
        }
    }
}