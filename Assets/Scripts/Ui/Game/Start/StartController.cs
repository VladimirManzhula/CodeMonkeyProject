using System;
using Core.Inputs;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Ui.Game.Start
{
    public class StartController : UiController<StartView>, IInitializable, IDisposable
    {
        private const int TIME_WAITING = 3;
        
        private readonly SignalBus _signalBus;
        private readonly IInputManager _inputManager;

        private IDisposable _intervalDisposable = Disposable.Empty;
        
        public StartController(
            SignalBus signalBus,
            IInputManager inputManager
        )
        {
            _signalBus = signalBus;
            _inputManager = inputManager;
        }

        public void Initialize()
        {
            _intervalDisposable = Observable.Interval(TimeSpan.FromSeconds(1f))
                .Subscribe(OnInterval);
        }
        
        private void OnInterval(long elapsedTime)
        {
            var leftValue = TIME_WAITING - (int)elapsedTime;
            View.SetTime(leftValue);

            if (leftValue != 0)
                return;

            _intervalDisposable.Dispose();
            _signalBus.BackWindow();
            _inputManager.IsActiveInput = true;
        }

        public void Dispose() => _intervalDisposable?.Dispose();
    }
}