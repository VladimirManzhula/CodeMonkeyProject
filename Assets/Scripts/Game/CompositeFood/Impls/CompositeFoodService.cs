using System.Collections.Generic;
using Databases.CompositeEndurables;
using Databases.EndurableModels;
using Game.Factories;
using Game.Models.Abstract;
using Game.Models.Endurables;

namespace Game.CompositeFood.Impls
{
    public class CompositeFoodService : ICompositeFoodService
    {
        private readonly ICompositeEndurableSettingBase _compositeEndurableSettingBase;
        private readonly IEndurableFactory _endurableFactory;

        public CompositeFoodService(
            ICompositeEndurableSettingBase compositeEndurableSettingBase,
            IEndurableFactory endurableFactory
        )
        {
            _compositeEndurableSettingBase = compositeEndurableSettingBase;
            _endurableFactory = endurableFactory;
        }

        public void CreateCompositeFood(IStorableModel player, IStorableModel interactable)
        {
            var playerEndurable = player.EndurableModel.Value;
            var interactableEndurable = interactable.EndurableModel.Value;
            var playerEndurableType = playerEndurable.Type;
            var interactableEndurableType = interactableEndurable.Type;

            if (!_compositeEndurableSettingBase.IsAvailableToAdd(
                    EEndurableType.CookedBurger,
                    playerEndurableType
                ))
                return;

            if (interactableEndurable.SubTypes.Count == 0)
            {
                var compositeEndurable = CreateCompositeEndurable(
                    playerEndurable.Type, interactableEndurable.Type
                );

                interactableEndurable.IsDestroyed.Value = true;
                interactable.SetEndurableModel(compositeEndurable);
                playerEndurable.IsDestroyed.Value = true;
                player.ClearEndurableModel();
                return;
            }

            if (interactableEndurableType != EEndurableType.CookedBurger) 
                return;
            
            interactableEndurable.AddSubType(playerEndurableType);
            playerEndurable.IsDestroyed.Value = true;
            player.ClearEndurableModel();
        }
        
        private IEndurableModel CreateCompositeEndurable(
            EEndurableType firstSybType,
            EEndurableType secondSybType
        )
        {
            var types = new List<EEndurableType>() { firstSybType, secondSybType};
            return _endurableFactory.CreateComposite(EEndurableType.CookedBurger, types);
        }
    }
}