using System;
using Databases.EndurableModels;

namespace Databases.EndurableTransformation
{
    [Serializable]
    public struct EndurableTransformationSettingVo
    {
        public EEndurableType from;
        public EEndurableType to;
        public ETransformationType transformationType;
        public int countInteractions;
    }
}