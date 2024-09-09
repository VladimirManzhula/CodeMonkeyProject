using Game.Models.Players;
using UnityEngine;

namespace Game.DataHolders.Impls
{
    public class PlayerModelDataHolder : ADataHolder<IPlayerModel>, IPlayerModelDataHolder
    {
        public Vector3 PlayerPosition => Model.Transform.position;
    }
}