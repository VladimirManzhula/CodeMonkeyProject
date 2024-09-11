using System;
using Game.Models.InteractableObjects.Impls;
using Game.Views.InteractableObjects.Impls;

namespace Game.Services.InteractObjects.Impls
{
    public class IntervalSpawningInteractableStrategy : AInteractableStrategy<IntervalSpawningInteractableObjectView,
        IntervalSpawningInteractableObjectModel>, IDisposable
    {
        public override EInteractableType Type => EInteractableType.IntervalSpawning;
        protected override IntervalSpawningInteractableObjectModel GetModel(IntervalSpawningInteractableObjectView view)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}