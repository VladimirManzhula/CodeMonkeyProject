using UnityEngine;

namespace Databases.CameraSettings.Impls
{
    [CreateAssetMenu(
        menuName = "Databases/" + nameof(CameraSettingsDao),
        fileName = nameof(CameraSettingsDao), order = 0
    )]
    public class CameraSettingsDao : ScriptableObject, ICameraSettingsDao
    {
        [SerializeField] private Vector3 playerRelativeOffset;
        [SerializeField] private Vector3 rotation;

        public Vector3 PlayerRelativeOffset => playerRelativeOffset;
        public Vector3 Rotation => rotation;
    }
}