using Game.Services.InstantiatingViews.Creators;
using UnityEngine;

namespace Game.Factories.View
{
    public interface IGameViewFactory
    {
        TView CreateByType<TView>(EGameViewType type)
            where TView : MonoBehaviour;
    }
}