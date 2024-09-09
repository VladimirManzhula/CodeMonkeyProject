using Game.Models.Players;
using UnityEngine;

namespace Game.DataHolders
{
    public interface IPlayerModelDataHolder : IDataHolder<IPlayerModel>
    {
        Vector3 PlayerPosition { get; }
    }
}