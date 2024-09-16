using Core.Services.Scenes;
using SimpleUi.Abstracts;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ui.Menu.Menu
{
    public class MenuController : UiController<MenuView>, IInitializable
    {
        private readonly ISceneService _sceneService;

        public MenuController(ISceneService sceneService)
        {
            _sceneService = sceneService;
        }
        
        public void Initialize()
        {
            View.PlayButton.OnClickAsObservable().Subscribe(OnPlay).AddTo(View);
            View.QuitButton.OnClickAsObservable().Subscribe(OnQuit).AddTo(View);
        }

        private void OnPlay(Unit obj) => _sceneService.LoadScene(ScenePlace.Game);
        private void OnQuit(Unit obj) => Application.Quit();
    }
}