using System;
using Game.Services.DAO.Settings.Audio.Sounds.Impls;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Databases.Audio.Impls
{
    public class AudioSettingsBase : IAudioSettingsBase
    {
        private readonly IAudioSettingsDao _audioSettingsDao;

        public AudioSettingsBase(IAudioSettingsDao audioSettingsDao)
        {
            _audioSettingsDao = audioSettingsDao;
        }

        public SoundsPlayer SoundsPlayer => _audioSettingsDao.SoundsPlayer;

        public AudioClip GetClipByType(ESoundType type)
        {
            foreach (var vo in _audioSettingsDao.Vos)
            {
                if (vo.type != type)
                    continue;

                var clipsLength = vo.clips.Length;
                var randomIndex = Random.Range(0, clipsLength);
                return vo.clips[randomIndex];
            }

            throw new Exception($"{nameof(AudioSettingsBase)} Doesn't exist settings with type : {type}");
        }
    }
}