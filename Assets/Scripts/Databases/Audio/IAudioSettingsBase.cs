using Game.Services.Audio.Sounds.Impls;
using UnityEngine;

namespace Databases.Audio
{
    public interface IAudioSettingsBase
    {
        SoundsPlayer SoundsPlayer { get; }

        AudioClip GetClipByType(ESoundType type);
    }
}