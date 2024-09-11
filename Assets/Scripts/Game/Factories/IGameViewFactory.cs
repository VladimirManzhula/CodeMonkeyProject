using UnityEngine;

namespace Game.Factories
{
    public interface IGameViewFactory
    {
        TView CreateByType<TView>(EGameViewType type)
            where TView : MonoBehaviour;
    }
}