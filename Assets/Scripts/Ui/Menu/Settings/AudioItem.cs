using UnityEngine;
using UnityEngine.UI;

namespace Ui.Menu.Settings
{
    public class AudioItem : MonoBehaviour
    {
        [SerializeField] private Image musicImage;
        [SerializeField] private Image soundImage;
        
        [SerializeField] private Button musicButton;
        [SerializeField] private Button soundButton;
        
        public Button MusicButton => musicButton;
        public Button SoundButton => soundButton;
        
        public void MusicImage(Sprite sprite) => musicImage.sprite = sprite;
        public void SoundImage(Sprite sprite) => soundImage.sprite = sprite;
    }
}