using UniRx;
using Zenject;

namespace Game.Services.DAO.Settings.Audio.Service.Impls
{
    public class AudioEventService : IAudioEventService, IInitializable
    {
        private readonly ISettingsState _settingsState;

        public AudioEventService(
            ISettingsState settingsState
        )
        {
            _settingsState = settingsState;
        }

        public void Initialize()
        {
            IsMusic.Value = _settingsState.GetAudioSettings().isMusic;
            IsSound.Value = _settingsState.GetAudioSettings().isSound;
        }
        
        public ReactiveCommand<bool> InterruptingMusic { get; } = new();

        public BoolReactiveProperty IsMusic { get; } = new();

        public BoolReactiveProperty IsSound { get; } = new();

        public void SetMusic()
        {
            _settingsState.SetAudioMusicSettings();
            IsMusic.Value = !IsMusic.Value;
        }

        public void SetSound()
        {
            _settingsState.SetAudioSoundSettings();
            IsSound.Value = !IsSound.Value;
        }
    }
}