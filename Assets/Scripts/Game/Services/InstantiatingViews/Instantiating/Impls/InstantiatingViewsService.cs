using System.Collections.Generic;
using Game.Services.InstantiatingViews.Creators;
using Zenject;

namespace Game.Services.InstantiatingViews.Instantiating.Impls
{
    public class InstantiatingViewsService : IInstantiatingViewsService, IInitializable
    {
        private readonly List<IViewCreator> _viewCreators;

        public InstantiatingViewsService(List<IViewCreator> viewCreators)
        {
            _viewCreators = viewCreators;
        }

        public void Initialize()
        {
            foreach (var viewCreator in _viewCreators)
                viewCreator.Create();
        }
    }
}