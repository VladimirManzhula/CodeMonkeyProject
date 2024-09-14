using System;
using Databases.Audio;
using Game.DataHolders;
using Game.Services.Audio.Service;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Services.Audio.Sounds.Impls
{
    public class PlayerFootStepSounds : IInitializable, IDisposable
    {
        private readonly IPlayerModelDataHolder _playerModelDataHolder;
        private readonly IAudioService _audioService;

        private IDisposable _velocityDisposable = Disposable.Empty;
        private IDisposable _intervalDisposable = Disposable.Empty;

        private bool _isSound;

        public PlayerFootStepSounds(
            IPlayerModelDataHolder playerModelDataHolder,
            IAudioService audioService
        )
        {
            _playerModelDataHolder = playerModelDataHolder;
            _audioService = audioService;
        }

        public void Initialize()
        {
            var playerModel = _playerModelDataHolder.Model;
            _velocityDisposable = playerModel.GetVelocity
                .Subscribe(OnVelocityChanged);
            _intervalDisposable = Observable.Interval(TimeSpan.FromSeconds(0.15f))
                .Subscribe(OnInterval);
        }

        public void Dispose()
        {
            _velocityDisposable.Dispose();
            _intervalDisposable.Dispose();
        }

        private void OnVelocityChanged(Vector3 velocity) => _isSound = velocity != Vector3.zero;

        private void OnInterval(long l)
        {
            if(!_isSound)
                return;
            
            _audioService.PlaySfx(ESoundType.Footstep, _playerModelDataHolder.PlayerPosition);
        }
    }
}