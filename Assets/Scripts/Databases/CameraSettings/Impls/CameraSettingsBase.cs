using UnityEngine;

namespace Databases.CameraSettings.Impls
{
    public class CameraSettingsBase : ICameraSettingsBase
    {
        private readonly ICameraSettingsDao _cameraSettingsDao;

        public CameraSettingsBase(ICameraSettingsDao cameraSettingsDao)
        {
            _cameraSettingsDao = cameraSettingsDao;
        }
        
        public Vector3 PlayerRelativeOffset => _cameraSettingsDao.PlayerRelativeOffset;
        public Vector3 Rotation => _cameraSettingsDao.Rotation;
    }
}