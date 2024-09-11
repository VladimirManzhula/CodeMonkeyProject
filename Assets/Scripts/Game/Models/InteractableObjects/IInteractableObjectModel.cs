using System;
using Game.Services.InteractObjects;
using Game.Views.InteractableObjects;

namespace Game.Models.InteractableObjects
{
    public interface IInteractableObjectModel
    {
        EInteractableType Type { get; }
        
        IInteractableObjectView View { get; }
        
        Action ExecutingAction { get; }
        
        Action AlternativeExecutingAction { get; }
        
        bool IsViewInteractionPossible { get; }
        
        bool IsViewAlternativeInteractionPossible { get; }
    }
}