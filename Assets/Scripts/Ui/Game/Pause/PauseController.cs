using Core.Providers;
using Core.Services.Scenes;
using Databases.ImageSwitcher.SettingsImageSwitcher;
using Game.Services.DAO.Settings.Audio.Service;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Ui.Game.Pause
{
    public class PauseController : UiController<PauseView>, IInitializable
    {
        private readonly SignalBus _signalBus;
        private readonly ITimeProvider _timeProvider;
        private readonly ISceneService _sceneService;
        private readonly IAudioEventService _audioEventService;
        private readonly ISettingsImageSwitcherBase _settingsImageSwitcherBase;

        public PauseController(
            SignalBus signalBus,
            ITimeProvider timeProvider,
            ISceneService sceneService,
            IAudioEventService audioEventService,
            ISettingsImageSwitcherBase settingsImageSwitcherBase
        )
        {
            _signalBus = signalBus;
            _timeProvider = timeProvider;
            _sceneService = sceneService;
            _audioEventService = audioEventService;
            _settingsImageSwitcherBase = settingsImageSwitcherBase;
        }

        public void Initialize()
        {
            View.ResumeButton.OnClickAsObservable().Subscribe(OnResume).AddTo(View);
            View.BackMenuButton.OnClickAsObservable().Subscribe((OnBackMenu)).AddTo(View);
            View.AudioItem.MusicButton.OnClickAsObservable().Subscribe(OnMusic).AddTo(View);
            View.AudioItem.SoundButton.OnClickAsObservable().Subscribe(OnSound).AddTo(View);
        }

        public override void OnShow()
        {
            _timeProvider.TimeScale = 0;
            
            var musicSprite = _settingsImageSwitcherBase.GetAudioImageSupport(EAudioType.Music, _audioEventService.IsMusic.Value);
            var soundSprite = _settingsImageSwitcherBase.GetAudioImageSupport(EAudioType.Sound, _audioEventService.IsSound.Value);
            
            View.AudioItem.MusicImage(musicSprite);
            View.AudioItem.SoundImage(soundSprite);
        }

        private void OnResume(Unit _)
        {
            _timeProvider.TimeScale = 1;
            _signalBus.BackWindow();
        }

        private void OnBackMenu(Unit _)
        {
            _timeProvider.TimeScale = 1;
            _sceneService.LoadScene(ScenePlace.Menu);
        }
        
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