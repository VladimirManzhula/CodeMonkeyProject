using Core.Providers.Impls;
using Core.Services.Scenes.Impls;
using Game.Services.DAO.Settings.Impls;
using Game.Services.DAO.Settings.Services.Impls;
using Project.Windows;
using Zenject;

namespace Installers.Project
{
    public class ProjectInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            SetSettings();
            Bind();
            BindServices();
            BindWindows();
            BindDao();
        }

        private void SetSettings()
        {
            SignalBusInstaller.Install(Container); 
        }

        private void Bind()
        {
            Container.BindInterfacesTo<TimeProvider>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<SceneService>().AsSingle();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<LoadingWindow>().AsSingle();
        }
        
        private void BindDao()
        {
            //Settings
            Container.BindInterfacesTo<SettingsDao>().AsSingle()
                .WithArguments("Settings.json");
            
            Container.BindInitializableExecutionOrder<SettingsState>(-10000);
            Container.BindInterfacesTo<SettingsState>().AsSingle();
        }
    }
}