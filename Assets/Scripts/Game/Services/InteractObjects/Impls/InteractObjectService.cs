using System.Collections.Generic;
using Game.Models.InteractableObjects;
using Game.Views.InteractableObjects;

namespace Game.Services.InteractObjects.Impls
{
    public class InteractObjectService : IInteractObjectService
    {
        private readonly IInteractableStrategy[] _interactableStrategies;

        private readonly List<IInteractableObjectModel> _interactableModels = new();

        public InteractObjectService(
            IReadOnlyList<IInteractableStrategy> strategies
        )
        {
            _interactableStrategies = new IInteractableStrategy[strategies.Count];

            for (var index = 0; index < strategies.Count; index++)
            {
                var strategy = strategies[index];
                var strategyIndex = (int)strategy.Type;
                _interactableStrategies[strategyIndex] = strategy;
            }
        }

        public IInteractableObjectModel[] CreateInteractableModels(
            IInteractableObjectView[] interactableObjectViews
        )
        {
            var models = new IInteractableObjectModel[interactableObjectViews.Length];

            for (var i = 0; i < interactableObjectViews.Length; i++)
            {
                var view = interactableObjectViews[i];
                var type = view.Type;
                var index = (int)type;
                var model = _interactableStrategies[index].GetInteractableObjectModel(view);
                models[i] = model;
            }

            return models;
        }

        public void AddInteractModel(IInteractableObjectModel model)
        {
            _interactableModels.Add(model);
            model.View.OnPlayerEnter();
        }

        public void Execute()
        {
            var model = GetLastInteractableObjectModel();
            model.ExecutingAction();
            
            if(!model.IsViewInteractionPossible)
                return;
            
            model.View.Interact();
        }

        public void ExecuteAlternative()
        {
            var lastInteractableObjectModel = GetLastInteractableObjectModel();
            lastInteractableObjectModel?.AlternativeExecutingAction();
            
            if(!lastInteractableObjectModel.IsViewAlternativeInteractionPossible)
                return;
            
            lastInteractableObjectModel?.View.InteractAlternative();
        }

        public void RemoveInteractableModel(IInteractableObjectModel model)
        {
            _interactableModels.Remove(model);
            model.View.OnPlayerExit();
        }

        private IInteractableObjectModel GetLastInteractableObjectModel()
        {
            var lastModelIndex = _interactableModels.Count - 1;
            return _interactableModels[lastModelIndex];
        }
    }
}