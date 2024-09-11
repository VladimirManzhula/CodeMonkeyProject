using Game.Models.Endurables;
using UniRx;
using UnityEngine;

namespace Game.Models.Abstract
{
    public abstract class AStorableModel : IStorableModel
    {
        private readonly ReactiveProperty<IEndurableModel> _endurableModel = new();
        public IReactiveProperty<IEndurableModel> EndurableModel => _endurableModel;
        
        public void SetEndurableModel(IEndurableModel model)
        {
            _endurableModel.Value = model;
            model.ParentTransform.Value = GetStorableTransform();
        }

        public void ClearEndurableModel() => _endurableModel.Value = null;

        protected abstract Transform GetStorableTransform();
    }
}