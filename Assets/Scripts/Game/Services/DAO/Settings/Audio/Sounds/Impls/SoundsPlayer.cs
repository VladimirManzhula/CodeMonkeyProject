using UnityEngine;

namespace Game.Services.DAO.Settings.Audio.Sounds.Impls
{
    public class SoundsPlayer : MonoBehaviour, ISoundPlayer
    {
        [SerializeField] private AudioSource backgroundSource;
        [SerializeField] private AudioSource fryingSource;
        
        public void PlayBackground(AudioClip backgroundClip, bool isPlaying)
        {
            if (isPlaying == false)
            {
                backgroundSource.Stop();
                return;
            }
            
            backgroundSource.clip = backgroundClip;
            backgroundSource.Play();
        }

        public void PlayFrying(AudioClip fryingClip, bool isPlaying)
        {
            if (isPlaying == false)
            {
                fryingSource.Stop();
                return;
            }
            
            fryingSource.clip = fryingClip;
            fryingSource.Play();
        }
    }
}