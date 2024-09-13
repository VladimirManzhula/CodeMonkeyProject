using Game.CompositeFood;
using Game.Models.Abstract;

namespace Game.Services.Exchanges.Impls
{
    public class ExchangeService : IExchangeService
    {
        private readonly ICompositeFoodService _compositeFoodService;

        public ExchangeService(
            ICompositeFoodService compositeFoodService
        )
        {
            _compositeFoodService = compositeFoodService;
        }

        public void Execute(IStorableModel player, IStorableModel interactable)
        {
            if (player.EndurableModel.Value != null)
            {
                if (interactable.EndurableModel.Value != null)
                {
                    _compositeFoodService.CreateCompositeFood(player, interactable);
                    return;
                }

                Exchange(player, interactable);
            }
            else
            {
                if (interactable.EndurableModel.Value == null)
                    return;

                Exchange(interactable, player);
            }
        }

        private static void Exchange(IStorableModel destination, IStorableModel source)
        {
            source.SetEndurableModel(destination.EndurableModel.Value);
            destination.ClearEndurableModel();
        }
    }
}