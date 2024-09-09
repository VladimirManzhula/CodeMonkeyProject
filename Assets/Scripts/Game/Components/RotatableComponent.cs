using System;
using Game.Models.Abstract;
using UniRx;
using UnityEngine;

namespace Game.Components
{
    public class RotatableComponent : MonoBehaviour
    {
        private IDisposable _rotationDisposable = Disposable.Empty;
        private IDisposable _everyFixedUpdateDisposable = Disposable.Empty;
        private Vector3 _goalDirection;

        public void SubscribeOnDirectionChanged(IVelocityMovableModel model)
        {
            void OnDirectionChanged(Vector3 direction)
            {
                if(direction == Vector3.zero)
                    return;

                _goalDirection = model.GetVelocity.Value.normalized;

                _everyFixedUpdateDisposable = Observable.EveryFixedUpdate()
                    .Subscribe(OnEveryFixedUpdate);
            }
            
            _rotationDisposable = model.GetVelocity
                .Subscribe(OnDirectionChanged);
        }

        private void OnDestroy() => _rotationDisposable.Dispose();

        private void OnEveryFixedUpdate(long l)
        {
            var dot = Vector3.Dot(transform.forward, _goalDirection);

            if (Math.Abs(dot - 1) > 0.001)
            {
                transform.forward = Vector3.Slerp(transform.forward, _goalDirection, Time.deltaTime);
                return;
            }
                    
            _everyFixedUpdateDisposable.Dispose();
        }
    }
}