using Game.Models.Abstract;
using UnityEngine;

namespace Game.Models.Players
{
    public interface IPlayerModel : IVelocityMovableModel, IStorableModel
    {
        Transform Transform { get; }
    }
}