using Game.Models.InteractableObjects;
using Game.Views.InteractableObjects;

namespace Game.Services.InteractObjects
{
    public abstract class AInteractableStrategy<TView, TModel> : IInteractableStrategy
        where TView : IInteractableObjectView
        where TModel : IInteractableObjectModel
    {
        public abstract EInteractableType Type { get; }
        
        public IInteractableObjectModel GetInteractableObjectModel(IInteractableObjectView view)
        {
            var interactableObjectView = (TView)view;
            OnViewInitialize(interactableObjectView);
            return GetModel(interactableObjectView);
        }

        protected abstract TModel GetModel(TView view);
        
        protected virtual void OnViewInitialize(TView view)
        {}
    }
}