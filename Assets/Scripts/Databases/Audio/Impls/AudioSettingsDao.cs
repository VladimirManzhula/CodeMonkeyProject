using Core.Exceptions.Drawers;
using Game.Services.Audio.Sounds.Impls;
using UnityEngine;

namespace Databases.Audio.Impls
{
    [CreateAssetMenu(
        menuName = "Databases/" + nameof(AudioSettingsDao),
        fileName = nameof(AudioSettingsDao), order = 0
    )]
    public class AudioSettingsDao : ScriptableObject, IAudioSettingsDao
    {
        [SerializeField] private SoundsPlayer soundsPlayer;

        [KeyValue("type")]
        [SerializeField] private SoundSettingsVo[] vos;

        public SoundsPlayer SoundsPlayer => soundsPlayer;
        public SoundSettingsVo[] Vos => vos;
    }
}