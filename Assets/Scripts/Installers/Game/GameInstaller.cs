using Core.Inputs.Impls;
using Game.DataHolders.Impls;
using Game.Factories.View.Impls;
using Game.Services.CameraFollowing;
using Game.Services.CameraFollowing.Impls;
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
            BindDataHolders();
            BindFactories();
        }

        private void BindManagers()
        { 
            Container.BindInterfacesTo<GameWindowManager>().AsSingle();
            Container.BindInterfacesTo<InputManager>().AsSingle();
        }

        private void BindService()
        {
            Container.BindInterfacesTo<InstantiatingViewsService>().AsSingle();
            Container.BindInterfacesTo<CameraFollowingService>().AsSingle();
        }

        private void BindViewCreators()
        {
            Container.BindInterfacesTo<LevelViewCreator>().AsSingle();
            Container.BindInterfacesTo<PlayerViewCreator>().AsSingle();
            Container.BindInterfacesTo<CameraViewCreator>().AsSingle();
        }
        
        private void BindDataHolders()
        {
            Container.BindInterfacesTo<PlayerModelDataHolder>().AsSingle();
            Container.BindInterfacesTo<CameraModelDataHolder>().AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesTo<GameViewFactory>().AsSingle();
        }
    }
}