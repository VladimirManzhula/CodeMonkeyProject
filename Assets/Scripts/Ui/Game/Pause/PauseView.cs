using SimpleUi.Abstracts;
using Ui.Menu.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Game.Pause
{
    public class PauseView : UiView
    {
        [SerializeField] private AudioItem audioItem;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button backMenuButton;

        public AudioItem AudioItem => audioItem;
        public Button ResumeButton => resumeButton;
        public Button BackMenuButton => backMenuButton;
    }
}