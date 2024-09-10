using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Game.Models.Players.Impls
{
    public class PlayerModel : IPlayerModel
    {
        private readonly Vector3ReactiveProperty _getVelocity = new(Vector3.zero);
        public IReadOnlyReactiveProperty<Vector3> GetVelocity => _getVelocity;

        private Vector3 _setVelocityDirection;
        
        public Vector3 SetVelocityDirection
        {
            set => _getVelocity.Value = value;
        }

        public Transform Transform { get; }
        public Transform PickingTransform { get; }
        
        public PlayerModel(
            Transform transform,
            Transform pickingTransform
        )
        {
            Transform = transform;
            PickingTransform = pickingTransform;
        }
    }
}