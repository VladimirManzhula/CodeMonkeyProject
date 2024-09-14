using System;
using UnityEngine;

namespace Databases.Audio
{
    [Serializable]
    public struct SoundSettingsVo
    {
        public ESoundType type;
        public AudioClip[] clips;
    }
}