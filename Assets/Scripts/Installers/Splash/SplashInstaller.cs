using Game.Services.DAO.Settings.Keyboard.Services.Impls;
using Ui.Splash;
using Ui.Splash.Windows;
using Zenject;

namespace Installers.Splash
{
    public class SplashInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindManagers();
            BindServices();
            BindWindows();
            
        }

        private void BindManagers()
        {
            Container.BindInterfacesTo<SplashWindowManager>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<KeyboardService>().AsSingle();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<SplashWindow>().AsSingle();
        }
    }
}