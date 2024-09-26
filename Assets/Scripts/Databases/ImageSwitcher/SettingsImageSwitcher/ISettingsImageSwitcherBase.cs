using UnityEngine;

namespace Databases.ImageSwitcher.SettingsImageSwitcher
{
    public interface ISettingsImageSwitcherBase
    {
        Sprite GetAudioImageSupport(EAudioType eAudioType, bool isAudio);
    }
}