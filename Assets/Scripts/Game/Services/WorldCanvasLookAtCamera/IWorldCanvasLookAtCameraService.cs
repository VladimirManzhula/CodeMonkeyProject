using Game.Views.InteractableObjects;
using Zenject;

namespace Game.Services.WorldCanvasLookAtCamera
{
    public interface IWorldCanvasLookAtCameraService : ILateTickable
    {
        void Add(IWorldCanvasView view);

        void Remove(IWorldCanvasView view);
    }
}