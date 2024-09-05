using Game.Views;

namespace Databases.GameModels
{
    public interface IGameModelDao
    {
        LocationView LocationView { get; }
        GameModelVo[] GameModelVos { get; }
    }
}