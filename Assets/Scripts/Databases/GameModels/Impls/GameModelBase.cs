using System;
using Core.Exceptions;
using Game.Services.InstantiatingViews.Creators;
using Game.Views;

namespace Databases.GameModels.Impls
{
    public class GameModelBase : IGameModelBase
    {
        private readonly IGameModelDao _gameModelDao;

        public GameModelBase(IGameModelDao gameModelDao)
        {
            _gameModelDao = gameModelDao;
        }

        public LocationView Location => _gameModelDao.LocationView;

        public TView GetViewByType<TView>(EGameViewType type)
        {
            foreach (var vo in _gameModelDao.GameModelVos)
            {
                if(vo.gameViewType != type)
                    continue;

                var view = vo.gameView.GetComponent<TView>();

                if (view == null)
                    throw new GameViewWithoutViewComponentException(type.ToString());

                return view;
            }

            throw new Exception($"{nameof(GameModelDao)} doesn't exist game model for type: {type.ToString()}.");
        }
    }
}