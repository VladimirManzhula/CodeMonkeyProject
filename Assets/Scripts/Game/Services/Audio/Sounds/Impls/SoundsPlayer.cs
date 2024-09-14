using UnityEngine;

namespace Game.Services.Audio.Sounds.Impls
{
    public class SoundsPlayer : MonoBehaviour, ISoundPlayer
    {
        [SerializeField] private AudioSource backgroundSource;
        [SerializeField] private AudioSource fryingSource;
        
        public void PlayBackground(AudioClip backgroundClip)
        {
            backgroundSource.clip = backgroundClip;
            backgroundSource.Play();
        }

        public void PlayFrying(AudioClip fryingClip)
        {
            fryingSource.clip = fryingClip;
            fryingSource.Play();
        }
    }
}