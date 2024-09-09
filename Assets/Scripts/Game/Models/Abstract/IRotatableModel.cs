using UniRx;
using UnityEngine;

namespace Game.Models.Abstract
{
    public interface IRotatableModel
    {
        IReadOnlyReactiveProperty<Vector3> GetRotation { get; }
        
        Vector3 SetRotation { set; }
    }
}