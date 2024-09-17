using SimpleUi.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Menu.Settings
{
    public class SettingsView : UiView
    {
        [SerializeField] private Button closeButton;
        
        public Button CloseButton => closeButton;
    }
}