using System;
using Databases.EndurableModels;

namespace Databases.IntervalSpawning
{
    [Serializable]
    public struct IntervalSpawningSettingVo
    {
        public EEndurableType type;
        public float interval;
        public int maxCount;
    }
}