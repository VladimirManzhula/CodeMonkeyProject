using SimpleUi.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Menu.Menu
{
    public class MenuView : UiView
    {
        [SerializeField] private Button playButton;
        
        public Button PlayButton => playButton;
    }
}