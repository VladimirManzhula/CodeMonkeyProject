using Core.Utils.Drawers;
using UnityEngine;

namespace Databases.ImageSwitcher.SettingsImageSwitcher.Impls
{
    [CreateAssetMenu(
        menuName = "Databases/" + nameof(SettingsImageSwitcherDao),
        fileName = nameof(SettingsImageSwitcherDao), order = 0
    )]
    public class SettingsImageSwitcherDao : ScriptableObject, ISettingsImageSwitcherDao
    {
        [KeyValue("eAudioType")]
        [SerializeField] private AudioImageSettings[] audioImageSettings;
        
        public AudioImageSettings[] AudioImageSettings => audioImageSettings;
    }
}