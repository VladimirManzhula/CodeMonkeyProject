using Game.Views.Endurables;
using UnityEngine;

namespace Databases.EndurableModels
{
    public interface IEndurableModelsBase
    {
        TView GetObjectByType<TView>(EEndurableType type)
            where TView : AEndurableView;
        
        Sprite GetSpriteByType(EEndurableType type);
    }
}