using UnityEngine;

namespace Databases.CameraSettings
{
    public interface ICameraSettingsBase
    {
        Vector3 PlayerRelativeOffset { get; }
        
        Vector3 Rotation { get; }
    }
}