using Ui.Menu;
using Ui.Menu.Windows;
using Zenject;

namespace Installers.Menu
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindManagers();
            BindWindows();
        }
        
        private void BindManagers()
        { 
            Container.BindInterfacesTo<MenuWindowManager>().AsSingle();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<MenuWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingsWindow>().AsSingle();
        }
    }
}