using System;
using Databases.Audio;
using Game.Services.DAO.Settings.Audio.Sounds;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Services.DAO.Settings.Audio.Service.Impls
{
    public class AudioService : IInitializable, IAudioService, IDisposable
    {
        private readonly IAudioSettingsBase _audioSettingsBase;
        private readonly IAudioEventService _audioEventService;
        private readonly DiContainer _container;
        
        private ISoundPlayer _soundPlayer;
        
        private readonly CompositeDisposable _disposable = new();

        public AudioService(
            IAudioSettingsBase audioSettingsBase,
            IAudioEventService audioEventService,
            DiContainer container
        )
        {
            _audioSettingsBase = audioSettingsBase;
            _audioEventService = audioEventService;
            _container = container;
        }

        public void Initialize()
        {
            var soundsPlayerPrefab = _audioSettingsBase.SoundsPlayer;
            _soundPlayer = _container.InstantiatePrefabForComponent<ISoundPlayer>(soundsPlayerPrefab);
            var backgroundClip = _audioSettingsBase.GetClipByType(ESoundType.Background);
            
            _audioEventService.IsMusic.Subscribe(_ => PlayMusicSfx(backgroundClip)).AddTo(_disposable);
            _audioEventService.InterruptingMusic
                .Subscribe(isPlaying => PlayMusicSfx(backgroundClip, isPlaying)).AddTo(_disposable);
        }
        
        public void PlayMusicSfx(AudioClip backgroundClip, bool isPlaying = true)
        {
            if (!_audioEventService.IsMusic.Value)
            {
                _soundPlayer.PlayBackground(backgroundClip, false);
                return;
            }
            
            _soundPlayer.PlayBackground(backgroundClip, isPlaying);
        }

        public void PlaySfx(ESoundType type, Vector3 position)
        {
            if (!_audioEventService.IsSound.Value)
                return;
            
            var clipByType = _audioSettingsBase.GetClipByType(type);
            AudioSource.PlayClipAtPoint(clipByType, position);
        }

        public void Dispose() => _disposable.Dispose();
    }
}