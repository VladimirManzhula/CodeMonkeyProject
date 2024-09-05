using Game.Factories.View;
using UnityEngine;

namespace Game.Services.InstantiatingViews.Creators.Impls
{
    public abstract class AViewCreator<TView> : IViewCreator
        where TView : MonoBehaviour
    {
        private readonly IGameViewFactory _gameViewFactory;

        protected AViewCreator(
            IGameViewFactory gameViewFactory
        )
        {
            _gameViewFactory = gameViewFactory;
        }

        protected abstract EGameViewType Type { get; }

        public void Create()
        {
            var tView = _gameViewFactory.CreateByType<TView>(Type);
            OnViewCreated(tView);
        }

        protected abstract void OnViewCreated(TView view);
    }
}