using Core.Inputs.Impls;
using Core.Services.OpenWindow.Impls;
using Game.CompositeFood.Impls;
using Game.DataHolders.Impls;
using Game.Factories.Impls;
using Game.Services.CameraFollowing.Impls;
using Game.Services.DAO.Settings.Audio.Service.Impls;
using Game.Services.DAO.Settings.Audio.Sounds.Impls;
using Game.Services.Exchanges.Impls;
using Game.Services.InstantiatingViews.Creators.Impls;
using Game.Services.InstantiatingViews.Instantiating.Impls;
using Game.Services.InteractObjects.Impls;
using Game.Services.PlayerInteractableCollisions.Impls;
using Game.Services.Recipes.Impls;
using Game.Services.WorldCanvasLookAtCamera.Impls;
using Ui.Game;
using Ui.Game.Windows;
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
            BindWindows();
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
            Container.BindInterfacesTo<ExchangeService>().AsSingle();
            Container.BindInterfacesTo<CompositeFoodService>().AsSingle();
            Container.BindInterfacesTo<RecipeService>().AsSingle();
            Container.BindInterfacesTo<AudioService>().AsSingle();
            Container.BindInterfacesTo<PlayerFootStepSounds>().AsSingle();
            Container.BindInterfacesTo<OpenWindowService>().AsSingle();
        }

        private void BindViewCreators()
        {
            Container.BindInterfacesTo<LevelViewInitializer>().AsSingle();
            Container.BindInterfacesTo<PlayerViewInitializer>().AsSingle();
            Container.BindInterfacesTo<CameraViewInitializer>().AsSingle();
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
        
        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<RecipeCollectionWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<PauseWindow>().AsSingle();
        }
    }
}