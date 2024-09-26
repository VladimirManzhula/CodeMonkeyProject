using System;
using Databases.ImageSwitcher.SettingsImageSwitcher.Impls;

namespace Databases.ImageSwitcher.SettingsImageSwitcher
{
    [Serializable]
    public class AudioImageSettings
    {
        public EAudioType eAudioType;
        public IsAudioImageSettings[] IsAudioImageSettings;
    }
}