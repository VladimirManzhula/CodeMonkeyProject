using SimpleUi.Signals;
using Ui.Menu.Windows;
using Zenject;

namespace Ui.Menu
{
    public class MenuWindowManager : IInitializable
    {
        private readonly SignalBus _signalBus;

        public MenuWindowManager(
            SignalBus signalBus
        )
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.OpenWindow<MenuWindow>();
        }
    }
}