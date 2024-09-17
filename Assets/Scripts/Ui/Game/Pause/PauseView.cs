using SimpleUi.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Game.Pause
{
    public class PauseView : UiView
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button backMenuButton;

        public Button ResumeButton => resumeButton;
        public Button BackMenuButton => backMenuButton;
    }
}