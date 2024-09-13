using Game.Models.Abstract;

namespace Game.Services.Exchanges
{
    public interface IExchangeService
    {
        void Execute(IStorableModel player, IStorableModel interactable);
    }
}