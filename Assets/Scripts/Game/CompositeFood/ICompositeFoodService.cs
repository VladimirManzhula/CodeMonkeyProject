using Game.Models.Abstract;

namespace Game.CompositeFood
{
    public interface ICompositeFoodService
    {
        void CreateCompositeFood(IStorableModel player, IStorableModel interactable);
    }
}