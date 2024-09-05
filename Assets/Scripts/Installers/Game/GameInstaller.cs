using Game.Factories.View.Impls;
using Game.Services.InstantiatingViews.Creators.Impls;
using Game.Services.InstantiatingViews.Instantiating.Impls;
using Ui.Game;
using Ui.Menu.Windows;
using Zenject;

namespace Installers.Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindManagers();
            BindService();
            BindViewCreators();
            BindFactories();
        }

        private void BindManagers()
        { 
            Container.BindInterfacesTo<GameWindowManager>().AsSingle();
        }

        private void BindService()
        {
            Container.BindInterfacesTo<InstantiatingViewsService>().AsSingle();
        }
        
        private void BindViewCreators()
        {
            Container.BindInterfacesTo<LevelViewCreator>().AsSingle();
            Container.BindInterfacesTo<PlayerViewCreator>().AsSingle();
            Container.BindInterfacesTo<CameraViewCreator>().AsSingle();
        }
        
        private void BindFactories()
        {
            Container.BindInterfacesTo<GameViewFactory>().AsSingle();
        }
    }
}