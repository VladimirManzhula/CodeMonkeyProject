using UniRx;

namespace Game.Services.DAO.Settings.Audio.Service
{
    public interface IAudioEventService
    {
        ReactiveCommand<bool> InterruptingMusic { get; }

        BoolReactiveProperty IsMusic { get;}
        BoolReactiveProperty IsSound { get;}

        void SetMusic();
        void SetSound();
    }
}