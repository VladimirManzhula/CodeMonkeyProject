using Game.Models.Abstract;
using UnityEngine;

namespace Game.Models.Players
{
    public interface IPlayerModel : IVelocityMovableModel
    {
        Transform Transform { get; }
    }
}