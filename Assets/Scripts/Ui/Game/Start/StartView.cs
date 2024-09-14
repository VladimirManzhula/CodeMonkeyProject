using SimpleUi.Abstracts;
using TMPro;
using UnityEngine;

namespace Ui.Game.Start
{
    public class StartView : UiView
    {
        [SerializeField] private TMP_Text timeText;

        public void SetTime(int time) => timeText.text = time.ToString();
    }
}