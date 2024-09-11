using System.Collections.Generic;
using Game.DataHolders;
using Game.Views.InteractableObjects;

namespace Game.Services.WorldCanvasLookAtCamera.Impls
{
    public class WorldCanvasLookAtCameraService : IWorldCanvasLookAtCameraService
    {
        private readonly ICameraModelDataHolder _cameraModelDataHolder;
        
        private readonly List<IWorldCanvasView> _worldCanvases = new();

        public WorldCanvasLookAtCameraService(
            ICameraModelDataHolder cameraModelDataHolder
        )
        {
            _cameraModelDataHolder = cameraModelDataHolder;
        }

        public void Add(IWorldCanvasView view) => _worldCanvases.Add(view);

        public void Remove(IWorldCanvasView view) => _worldCanvases.Remove(view);

        public void LateTick()
        {
            var cameraForward = _cameraModelDataHolder.Model.Transform.forward;

            for (var index = 0; index < _worldCanvases.Count; index++)
            {
                var worldCanvas = _worldCanvases[index];

                switch (worldCanvas.LookAtCameraType)
                {
                    case ELookAtCameraType.Forward:
                        worldCanvas.Canvas.transform.forward = cameraForward;
                        break;
                    case ELookAtCameraType.InverseForward:
                        worldCanvas.Canvas.transform.forward = -cameraForward;
                        break;
                }
                
            }
        }
    }
}