using Zenject;

namespace Ui.Game
{
    public class GameWindowManager : IInitializable
    {
        private readonly SignalBus _signalBus;

        public GameWindowManager(
            SignalBus signalBus
        )
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
        }
    }
}