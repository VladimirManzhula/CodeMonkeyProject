using System;
using Game.Models.Abstract;
using UniRx;
using UnityEngine;

namespace Game.Views.Camera
{
    public class CameraView : MonoBehaviour
    {
        private IDisposable _positionDisposable = Disposable.Empty;
        private IDisposable _rotationDisposable = Disposable.Empty;

        public void SubscribeOnPositionChanged(ITransformMovableModel model) =>
            _positionDisposable = model.GetPosition.Subscribe(OnPositionChanged);

        public void SubscribeOnRotationChanged(IRotatableModel model) =>
            _rotationDisposable = model.GetRotation.Subscribe(OnRotationChanged);

        private void OnPositionChanged(Vector3 position) => transform.position = position;

        private void OnRotationChanged(Vector3 rotation) => transform.rotation = Quaternion.Euler(rotation);

        private void OnDestroy()
        {
            _positionDisposable.Dispose();
            _rotationDisposable.Dispose();
        }
    }
}