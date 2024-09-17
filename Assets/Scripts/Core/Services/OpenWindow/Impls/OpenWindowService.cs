using System;
using Core.Constants;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Core.Services.OpenWindow.Impls
{
    public class OpenWindowService : IOpenWindowService, IInitializable, IDisposable
    {
        private readonly CompositeDisposable _disposables = new();
        private readonly SignalBus _signalBus;
        
        private string _isCurrentOpened;

        public OpenWindowService(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.GetStreamId<SignalActiveWindow>(EWindowLayer.Local)
                .Subscribe(OnActiveWindow)
                .AddTo(_disposables);
        }

        private void OnActiveWindow(SignalActiveWindow signal)
        {
            _isCurrentOpened = signal.Window.Name;
        }

        public bool IsWindowCurrentlyOpen(WindowNames.EGameType gameType) 
            => _isCurrentOpened == WindowNames.EGameType.Pause.ToString();

        public void Dispose() => _disposables.Dispose();
    }
}