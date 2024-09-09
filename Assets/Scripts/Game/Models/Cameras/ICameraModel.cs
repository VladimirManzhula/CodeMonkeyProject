using Game.Models.Abstract;
using UnityEngine;

namespace Game.Models.Cameras
{
    public interface ICameraModel : ITransformMovableModel, IRotatableModel
    {
        Transform Transform { get; }
    }
}