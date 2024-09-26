using SimpleUi.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Menu.Settings
{
    public class SettingsView : UiView
    {
        [SerializeField] private AudioItem audioItem;
        [SerializeField] private Button closeButton;
        
        public AudioItem AudioItem => audioItem;
        public Button CloseButton => closeButton;
    }
}