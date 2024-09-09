using UnityEngine;

namespace Databases.Players.Impls
{
    [CreateAssetMenu(
        menuName = "Databases/" + nameof(PlayerSettingDao),
        fileName = nameof(PlayerSettingDao), order = 0
    )]
    public class PlayerSettingDao : ScriptableObject, IPlayerSettingDao
    {
        [SerializeField] private float velocity;

        public float Velocity => velocity;
    }
}