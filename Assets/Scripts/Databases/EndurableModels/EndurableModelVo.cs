using System;
using Game.Views.Endurables;
using UnityEngine;

namespace Databases.EndurableModels
{
    [Serializable]
    public struct EndurableModelVo
    {
        public EEndurableType type;
        public AEndurableView endurableView;
        public Sprite sprite;
    }
}