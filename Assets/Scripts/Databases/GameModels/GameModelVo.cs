using System;
using Game.Services.InstantiatingViews.Creators;
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