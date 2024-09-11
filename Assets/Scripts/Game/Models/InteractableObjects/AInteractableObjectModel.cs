using System;
using Game.Services.InteractObjects;
using Game.Views.InteractableObjects;

namespace Game.Models.InteractableObjects
{
    public abstract class AInteractableObjectModel : IInteractableObjectModel
    {
        public EInteractableType Type { get; }
        public IInteractableObjectView View { get; }

        public Action ExecutingAction { get; set; }

        public Action AlternativeExecutingAction { get; set; }

        public virtual bool IsViewInteractionPossible => true;

        public virtual bool IsViewAlternativeInteractionPossible => true;

        protected AInteractableObjectModel(
            IInteractableObjectView view
        )
        {
            View = view;
            Type = view.Type;
        }
    }
}