using System;
using System.Collections.Generic;
using Core.Exceptions.Drawers;
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