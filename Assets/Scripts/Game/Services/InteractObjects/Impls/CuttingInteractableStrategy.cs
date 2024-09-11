using System;
using Game.Models.InteractableObjects.Impls;
using Game.Views.InteractableObjects.Impls;

namespace Game.Services.InteractObjects.Impls
{
    public class CuttingInteractableStrategy : AInteractableStrategy<CuttingInteractableObjectView,
        CuttingInteractableObjectModel>, IDisposable
    {

        public override EInteractableType Type => EInteractableType.Cutting;
        
        protected override CuttingInteractableObjectModel GetModel(CuttingInteractableObjectView view)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}