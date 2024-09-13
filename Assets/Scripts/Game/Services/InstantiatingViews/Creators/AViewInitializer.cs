using Game.Factories;
using UnityEngine;

namespace Game.Services.InstantiatingViews.Creators
{
    public abstract class AViewInitializer<TView> : IViewInitializer
        where TView : MonoBehaviour
    {
        private readonly IGameViewFactory _gameViewFactory;

        protected AViewInitializer(
            IGameViewFactory gameViewFactory
        )
        {
            _gameViewFactory = gameViewFactory;
        }

        protected abstract EGameViewType Type { get; }

        public void Initializer()
        {
            var tView = _gameViewFactory.CreateByType<TView>(Type);
            OnViewInitializer(tView);
        }

        protected abstract void OnViewInitializer(TView view);
    }
}