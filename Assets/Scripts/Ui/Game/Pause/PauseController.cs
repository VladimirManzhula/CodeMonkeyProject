using Core.Providers;
using Core.Services.Scenes;
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

        public PauseController(
            SignalBus signalBus,
            ITimeProvider timeProvider,
            ISceneService sceneService
        )
        {
            _signalBus = signalBus;
            _timeProvider = timeProvider;
            _sceneService = sceneService;
        }

        public void Initialize()
        {
            View.ResumeButton.OnClickAsObservable().Subscribe(OnResume).AddTo(View);
            View.BackMenuButton.OnClickAsObservable().Subscribe((OnBackMenu)).AddTo(View);
        }

        public override void OnShow() => _timeProvider.TimeScale = 0;

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
    }
}