using UniRx;

namespace Game.Models.Abstract
{
    public interface IDestroyableModel
    {
        IReactiveProperty<bool> IsDestroyed { get; }
    }
}