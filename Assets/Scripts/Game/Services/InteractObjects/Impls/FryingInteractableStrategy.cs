using System;
using Game.Models.InteractableObjects.Impls;
using Game.Views.InteractableObjects.Impls;

namespace Game.Services.InteractObjects.Impls
{
    public class FryingInteractableStrategy :
        AInteractableStrategy<FryingInteractableObjectView, FryingInteractableObjectModel>,
        IDisposable
    {
        public override EInteractableType Type => EInteractableType.Frying;
        
        protected override FryingInteractableObjectModel GetModel(FryingInteractableObjectView view)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}