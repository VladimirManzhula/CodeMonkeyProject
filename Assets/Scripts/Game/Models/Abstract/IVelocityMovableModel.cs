using UniRx;
using UnityEngine;

namespace Game.Models.Abstract
{
    public interface IVelocityMovableModel
    {
        IReadOnlyReactiveProperty<Vector3> GetVelocity { get; }

        Vector3 SetVelocityDirection { set; }
    }
}