using UniRx;
using UnityEngine;

namespace Game.Models.Abstract
{
    public interface ITransformMovableModel
    {
        IReadOnlyReactiveProperty<Vector3> GetPosition { get; }
        
        Vector3 SetPosition { set; }
    }
}