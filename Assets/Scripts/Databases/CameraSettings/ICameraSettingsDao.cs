using UnityEngine;

namespace Databases.CameraSettings
{
    public interface ICameraSettingsDao
    {
        Vector3 PlayerRelativeOffset { get; }
        
        Vector3 Rotation { get; }
    }
}