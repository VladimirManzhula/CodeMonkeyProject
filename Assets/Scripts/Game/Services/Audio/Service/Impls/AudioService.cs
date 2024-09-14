using Databases.Audio;
using Databases.Audio.Impls;
using Game.Services.Audio.Sounds;
using UnityEngine;
using Zenject;

namespace Game.Services.Audio.Service.Impls
{
    public class AudioService : IInitializable, IAudioService 
    {
        private readonly IAudioSettingsBase _audioSettingsBase;
        private readonly DiContainer _container;
        
        private ISoundPlayer _soundPlayer;

        public AudioService(
            IAudioSettingsBase audioSettingsBase,
            DiContainer container
        )
        {
            _audioSettingsBase = audioSettingsBase;
            _container = container;
        }

        public void Initialize()
        {
            var soundsPlayerPrefab = _audioSettingsBase.SoundsPlayer;
            _soundPlayer = _container.InstantiatePrefabForComponent<ISoundPlayer>(soundsPlayerPrefab);
            var backgroundClip = _audioSettingsBase.GetClipByType(ESoundType.Background);
            _soundPlayer.PlayBackground(backgroundClip);
        }

        public void PlaySfx(ESoundType type, Vector3 position)
        {
            var clipByType = _audioSettingsBase.GetClipByType(type);
            AudioSource.PlayClipAtPoint(clipByType, position);
        }
    }
}