using UniRx;
using UnityEngine;

namespace Game.Models.Cameras.Impls
{
    public class CameraModel : ICameraModel
    {
        private readonly Vector3ReactiveProperty _position = new();
        public IReadOnlyReactiveProperty<Vector3> GetPosition => _position;

        private readonly Vector3ReactiveProperty _rotation = new();
        public IReadOnlyReactiveProperty<Vector3> GetRotation => _rotation;

        public Vector3 SetPosition
        {
            set => _position.Value = value;
        }

        public Vector3 SetRotation
        {
            set => _rotation.Value = value;
        }

        public Transform Transform { get; }

        public CameraModel(Transform transform)
        {
            Transform = transform;
        }
    }
}