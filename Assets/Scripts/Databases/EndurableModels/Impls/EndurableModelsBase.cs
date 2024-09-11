using System.Linq;
using Game.Views.Endurables;
using UnityEngine;

namespace Databases.EndurableModels.Impls
{
    public class EndurableModelsBase : IEndurableModelsBase
    {
        private readonly IEndurableModelsDao _endurableModelsDao;

        public EndurableModelsBase(IEndurableModelsDao endurableModelsDao)
        {
            _endurableModelsDao = endurableModelsDao;
        }
        
        public TView GetObjectByType<TView>(EEndurableType type) where TView : AEndurableView =>
            GetVoByType(type).endurableView as TView;

        public Sprite GetSpriteByType(EEndurableType type) => GetVoByType(type).sprite;

        private EndurableModelVo GetVoByType(EEndurableType endurableType)
        {
            foreach (var vo in _endurableModelsDao.Vos)
            {
                if (vo.type != endurableType)
                    continue;

                return vo;
            }

            Debug.LogError(
                $"{nameof(EndurableModelsBase)} Doesn't exist settings with type : {endurableType}"
            );
            
            return _endurableModelsDao.Vos.First();
        }
    }
}