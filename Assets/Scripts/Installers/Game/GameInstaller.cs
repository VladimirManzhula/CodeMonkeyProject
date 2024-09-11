using Core.Inputs.Impls;
using Game.DataHolders.Impls;
using Game.Factories.Impls;
using Game.Services.CameraFollowing;
using Game.Services.CameraFollowing.Impls;
using Game.Services.InstantiatingViews.Creators.Impls;
using Game.Services.InstantiatingViews.Instantiating.Impls;
using Game.Services.InteractObjects.Impls;
using Game.Services.PlayerInteractableCollisions.Impls;
using Game.Services.WorldCanvasLookAtCamera.Impls;
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
            BindServices();
            BindViewCreators();
            BindDataHolders();
            BindFactories();
            BindStrategies();
        }

        private void BindManagers()
        { 
            Container.BindInterfacesTo<GameWindowManager>().AsSingle();
            Container.BindInterfacesTo<InputManager>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<InstantiatingViewsService>().AsSingle();
            Container.BindInterfacesTo<InteractObjectService>().AsSingle();
            Container.BindInterfacesTo<CameraFollowingService>().AsSingle();
            Container.BindInterfacesTo<PlayerInteractableCollisionsService>().AsSingle();
            Container.BindInterfacesTo<WorldCanvasLookAtCameraService>().AsSingle();
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
            Container.BindInterfacesTo<LevelModelDataHolder>().AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesTo<GameViewFactory>().AsSingle();
            Container.BindInterfacesTo<EndurableFactory>().AsSingle();
        }

        private void BindStrategies()
        {
            //Interactable strategy
            Container.BindInterfacesTo<SpawnFoodInteractableStrategy>().AsSingle();
            Container.BindInterfacesTo<StoringInteractableStrategy>().AsSingle();
            Container.BindInterfacesTo<CuttingInteractableStrategy>().AsSingle();
            Container.BindInterfacesTo<DestroyFoodIntractableStrategy>().AsSingle();
            Container.BindInterfacesTo<FryingInteractableStrategy>().AsSingle();
            Container.BindInterfacesTo<IntervalSpawningInteractableStrategy>().AsSingle();
            Container.BindInterfacesTo<DeliveryInteractableStrategy>().AsSingle();
        }
    }
}