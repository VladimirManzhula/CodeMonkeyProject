using System.Collections.Generic;
using Game.Services.InstantiatingViews.Creators;
using Zenject;

namespace Game.Services.InstantiatingViews.Instantiating.Impls
{
    public class InstantiatingViewsService : IInstantiatingViewsService, IInitializable
    {
        private readonly List<IViewInitializer> _viewInitializer;

        public InstantiatingViewsService(List<IViewInitializer> viewInitializer)
        {
            _viewInitializer = viewInitializer;
        }

        public void Initialize()
        {
            foreach (var viewInitializer in _viewInitializer)
                viewInitializer.Initializer();
        }
    }
}