using System;
using Game.Components;
using Game.Models.Abstract;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Game.Views.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerRigidbody;
        [SerializeField] private RotatableComponent rotatableComponent;
        [SerializeField] private PlayerAnimationComponent playerAnimationComponent;
        [SerializeField] private ObservableCollisionTrigger collisionTrigger;
        [SerializeField] private Transform pickingTransform;

        public Transform PickingTransform => pickingTransform;
        
        public ObservableCollisionTrigger CollisionTrigger => collisionTrigger;

        private void OnVelocityChanged(Vector3 value)
        {
            playerRigidbody.velocity = value;
            playerAnimationComponent.SetWalkableBool(value != Vector3.zero);
        }

        private IDisposable _velocityDisposable = Disposable.Empty;

        public void SubscribeOnVelocityChanged(IVelocityMovableModel model)
        {
            _velocityDisposable = model.GetVelocity
                .Subscribe(OnVelocityChanged);
            
            rotatableComponent.SubscribeOnDirectionChanged(model);
        }

        private void OnDestroy() => _velocityDisposable.Dispose();
    }
}