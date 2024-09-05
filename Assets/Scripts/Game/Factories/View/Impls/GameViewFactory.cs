using Databases.GameModels;
using Game.Services.InstantiatingViews.Creators;
using UnityEngine;
using Zenject;

namespace Game.Factories.View.Impls
{
    public class GameViewFactory : IGameViewFactory
    {
        private readonly IGameModelBase _gameModelBase;
        private readonly DiContainer _container;

        public GameViewFactory(
            IGameModelBase gameModelBase,
            DiContainer container
        )
        {
            _gameModelBase = gameModelBase;
            _container = container;
        }

        public TView CreateByType<TView>(EGameViewType type)
            where TView : MonoBehaviour
        {
            var viewPrefab = _gameModelBase.GetViewByType<TView>(type);
            var viewInstance = _container.InstantiatePrefabForComponent<TView>(viewPrefab);
            return viewInstance;
        }
    }
}