using Game.Models.Abstract;
using Game.Models.Endurables;
using Game.Views.InteractableObjects;
using UniRx;
using UnityEngine;

namespace Game.Models.InteractableObjects
{
    public abstract class AStorableInteractableObjectModel : AInteractableObjectModel, IStorableModel
    {
        private readonly ReactiveProperty<IEndurableModel> _endurableModel = new();
        public IReactiveProperty<IEndurableModel> EndurableModel => _endurableModel;

        protected AStorableInteractableObjectModel(
            IInteractableObjectView view
        ) : base(view)
        {
        }

        public void SetEndurableModel(IEndurableModel model)
        {
            _endurableModel.Value = model;
            model.ParentTransform.Value = GetStorableTransform();
        }

        public void ClearEndurableModel() => _endurableModel.Value = null;

        protected abstract Transform GetStorableTransform();
    }
}