using System.Collections.Generic;
using Game.Models.Abstract;
using Game.Models.Endurables;
using Game.Views.InteractableObjects;
using UniRx;
using UnityEngine;

namespace Game.Models.InteractableObjects.Impls
{
    public class IntervalSpawningInteractableObjectModel : AInteractableObjectModel, IStorableModel
    {
        private const float HEIGHT_BETWEEN_MODELS = 0.05f;
        
        private readonly List<IEndurableModel> _models = new();

        private readonly ReactiveProperty<IEndurableModel> _endurableModel = new();
        public IReactiveProperty<IEndurableModel> EndurableModel => _endurableModel;
        
        public Transform StartSpawnPoint { get; set; }

        public int ModelsCount => _models.Count;

        public IntervalSpawningInteractableObjectModel(
            IInteractableObjectView view
        ) : base(view)
        {
        }

        public void SetEndurableModel(IEndurableModel model)
        {
            _models.Add(model);
            _endurableModel.Value = model;
            model.ParentTransform.Value = StartSpawnPoint;
            model.Height.Value = (_models.Count - 1) * HEIGHT_BETWEEN_MODELS;
        }

        public void ClearEndurableModel()
        {
            var modelsCount = _models.Count;
            
            switch (modelsCount)
            {
                case 0:
                    return;
                case 1:
                    _endurableModel.Value = null;
                    return;
                default:
                    _endurableModel.Value = _models[modelsCount - 2];
                    _models.RemoveAt(modelsCount - 1);
                    break;
            }
        }
    }
}