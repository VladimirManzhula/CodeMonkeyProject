using System;
using System.Collections.Generic;
using Databases.EndurableModels;

namespace Databases.CompositeEndurables
{
    [Serializable]
    public struct CompositeEndurableSettingVo
    {
        public EEndurableType goal;
        public List<EEndurableType> availableTypes;
    }
}