using Core.Services.Scenes;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using Ui.Menu.Windows;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ui.Menu.Menu
{
    public class MenuController : UiController<MenuView>, IInitializable
    {
        private readonly SignalBus _signalBus;
        private readonly ISceneService _sceneService;

        public MenuController(
            SignalBus signalBus,
            ISceneService sceneService
        )
        {
            _signalBus = signalBus;
            _sceneService = sceneService;
        }
        
        public void Initialize()
        {
            View.PlayButton.OnClickAsObservable().Subscribe(OnPlay).AddTo(View);
            View.SettingsButton.OnClickAsObservable().Subscribe(OnSettings).AddTo(View);
            View.QuitButton.OnClickAsObservable().Subscribe(OnQuit).AddTo(View);
        }

        private void OnPlay(Unit obj) => _sceneService.LoadScene(ScenePlace.Game);
        private void OnSettings(Unit obj) => _signalBus.OpenWindow<SettingsWindow>();
        private void OnQuit(Unit obj) => Application.Quit();
    }
}