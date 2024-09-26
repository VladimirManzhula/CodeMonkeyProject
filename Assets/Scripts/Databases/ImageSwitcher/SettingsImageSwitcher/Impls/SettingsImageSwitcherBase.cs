using UnityEngine;

namespace Databases.ImageSwitcher.SettingsImageSwitcher.Impls
{
    public class SettingsImageSwitcherBase : ISettingsImageSwitcherBase
    {
        private readonly ISettingsImageSwitcherDao _settingsImageSwitcherDao;

        public SettingsImageSwitcherBase(
            ISettingsImageSwitcherDao settingsImageSwitcherDao
        )
        {
            _settingsImageSwitcherDao = settingsImageSwitcherDao;
        }

        public Sprite GetAudioImageSupport(EAudioType eAudioType, bool isAudio)
        {
            foreach (var audioSettings in _settingsImageSwitcherDao.AudioImageSettings)
            {
                if (audioSettings.eAudioType != eAudioType)
                    continue;

                var isAudioSettings = audioSettings.IsAudioImageSettings;
                foreach (var audio in isAudioSettings)
                {
                    if (audio.isAudio != isAudio)
                        continue;

                    return audio.sprite;
                }
                break;
            }

            Debug.LogError($"{nameof(SettingsImageSwitcherDao)} - The picture is missing");
            return null;
        }
    }
}