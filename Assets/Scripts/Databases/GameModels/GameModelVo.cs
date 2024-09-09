using System;
using Game.Factories.View;
using UnityEngine;

namespace Databases.GameModels
{
    [Serializable]
    public struct GameModelVo
    {
        public EGameViewType gameViewType;
        public GameObject gameView;
    }
}