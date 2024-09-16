using Core.Providers.Impls;
using Core.Services.OpenWindow.Impls;
using Core.Services.Scenes.Impls;
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
    }
}