using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Ui.Menu.Settings
{
    public class SettingsController : UiController<SettingsView>, IInitializable
    {
        private readonly SignalBus _signalBus;

        public SettingsController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            View.CloseButton.OnClickAsObservable().Subscribe(OnClose).AddTo(View);
        }

        private void OnClose(Unit _) => _signalBus.BackWindow();
    }
}