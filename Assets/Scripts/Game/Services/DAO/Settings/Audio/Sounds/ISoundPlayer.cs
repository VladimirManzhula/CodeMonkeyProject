using UnityEngine;

namespace Game.Services.DAO.Settings.Audio.Sounds
{
    public interface ISoundPlayer
    {
        void PlayBackground(AudioClip backgroundClip, bool isPlaying);
    }
}