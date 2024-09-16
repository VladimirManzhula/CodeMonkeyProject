using SimpleUi.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Menu.Menu
{
    public class MenuView : UiView
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;
        
        public Button PlayButton => playButton;
        public Button QuitButton => quitButton;
    }
}