using Game.Models.Endurables;
using UniRx;

namespace Game.Models.Abstract
{
    public interface IStorableModel
    {
        IReactiveProperty<IEndurableModel> EndurableModel { get;}

        void SetEndurableModel(IEndurableModel model);

        void ClearEndurableModel();
    }
}