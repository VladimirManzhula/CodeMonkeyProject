using Databases.ImageSwitcher.SettingsImageSwitcher;
using Game.Services.DAO.Settings.Audio.Service;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Ui.Menu.Settings
{
    public class SettingsController : UiController<SettingsView>, IInitializable
    {
        private readonly SignalBus _signalBus;
        private readonly IAudioEventService _audioEventService;
        private readonly ISettingsImageSwitcherBase _settingsImageSwitcherBase;

        public SettingsController(
            SignalBus signalBus,
            IAudioEventService audioEventService,
            ISettingsImageSwitcherBase settingsImageSwitcherBase
        )
        {
            _signalBus = signalBus;
            _audioEventService = audioEventService;
            _settingsImageSwitcherBase = settingsImageSwitcherBase;
        }

        public void Initialize()
        {
            View.CloseButton.OnClickAsObservable().Subscribe(OnClose).AddTo(View);
            View.AudioItem.MusicButton.OnClickAsObservable().Subscribe(OnMusic).AddTo(View);
            View.AudioItem.SoundButton.OnClickAsObservable().Subscribe(OnSound).AddTo(View);
        }
        
        public override void OnShow()
        {
            var musicSprite = _settingsImageSwitcherBase.GetAudioImageSupport(EAudioType.Music, _audioEventService.IsMusic.Value);
            var soundSprite = _settingsImageSwitcherBase.GetAudioImageSupport(EAudioType.Sound, _audioEventService.IsSound.Value);
            
            View.AudioItem.MusicImage(musicSprite);
            View.AudioItem.SoundImage(soundSprite);
        }

        private void OnClose(Unit _) => _signalBus.BackWindow();
        
        private void OnMusic(Unit _)
        {
            _audioEventService.SetMusic();
            var musicSprite = _settingsImageSwitcherBase.GetAudioImageSupport(EAudioType.Music, _audioEventService.IsMusic.Value);
            View.AudioItem.MusicImage(musicSprite);
        }

        private void OnSound(Unit _)
        {
            _audioEventService.SetSound();
            var soundSprite = _settingsImageSwitcherBase.GetAudioImageSupport(EAudioType.Sound, _audioEventService.IsSound.Value);
            View.AudioItem.SoundImage(soundSprite);
        }
    }
}