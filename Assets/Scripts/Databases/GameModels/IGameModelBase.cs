using Game.Services.InstantiatingViews.Creators;
using Game.Views;

namespace Databases.GameModels
{
    public interface IGameModelBase
    {
        LocationView Location { get; }
        
        TView GetViewByType<TView>(EGameViewType type);
    }
}