using Game.Views.InteractableObjects;

namespace Game.Services.WorldCanvasLookAtCamera
{
    public interface IWorldCanvasLookAtCameraService
    {
        void Add(IWorldCanvasView view);

        void Remove(IWorldCanvasView view);
    }
}