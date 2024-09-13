using Databases.CameraSettings;
using Game.DataHolders;
using Zenject;

namespace Game.Services.CameraFollowing.Impls
{
    public class CameraFollowingService : ICameraFollowingService, IInitializable, IFixedTickable
    {
        private readonly ICameraSettingsBase _cameraSettingsDatabase;
        private readonly IPlayerModelDataHolder _playerModelDataHolder;
        private readonly ICameraModelDataHolder _cameraModelDataHolder;

        public CameraFollowingService(
            ICameraSettingsBase cameraSettingsDatabase,
            IPlayerModelDataHolder playerModelDataHolder,
            ICameraModelDataHolder cameraModelDataHolder
        )
        {
            _cameraSettingsDatabase = cameraSettingsDatabase;
            _playerModelDataHolder = playerModelDataHolder;
            _cameraModelDataHolder = cameraModelDataHolder;
        }

        public void Initialize()
        {
            var cameraRotation = _cameraSettingsDatabase.Rotation;
            _cameraModelDataHolder.Model.SetRotation = cameraRotation;
        }

        public void FixedTick()
        {
            var playerTransform = _playerModelDataHolder.Model.Transform;
            var playerRelativeOffset = _cameraSettingsDatabase.PlayerRelativeOffset;
            var finalPosition = playerTransform.position + playerRelativeOffset;
            _cameraModelDataHolder.Model.SetPosition = finalPosition;
        }
    }
}