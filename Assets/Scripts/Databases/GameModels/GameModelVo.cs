using System;
using Game.Factories;
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