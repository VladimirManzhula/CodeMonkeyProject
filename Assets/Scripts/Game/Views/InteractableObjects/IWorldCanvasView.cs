using Game.Services.WorldCanvasLookAtCamera;
using UnityEngine;

namespace Game.Views.InteractableObjects
{
    public interface IWorldCanvasView
    {
        Canvas Canvas { get; }
        
        ELookAtCameraType LookAtCameraType { get; }
    }
}