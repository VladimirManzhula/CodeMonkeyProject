using Databases.EndurableModels;
using Databases.EndurableTransformation;
using UniRx;
using UnityEngine;

namespace Game.Models.Endurables.Impls
{
    public class EndurableModel : IEndurableModel
    {
        public EEndurableType Type { get; }

        private readonly ReactiveCollection<EEndurableType> _subTypes = new();
        public IReactiveCollection<EEndurableType> SubTypes => _subTypes;

        public ETransformationType TransformationType { get; set; }

        private readonly ReactiveProperty<Transform> _parentTransform = new();
        public IReactiveProperty<Transform> ParentTransform => _parentTransform;

        private readonly FloatReactiveProperty _height = new();
        public IReactiveProperty<float> Height => _height;

        private readonly BoolReactiveProperty _isDestroyed = new();

        public IReactiveProperty<bool> IsDestroyed => _isDestroyed;

        public float MaxProgress { get; set; }

        private readonly FloatReactiveProperty _currentProgress = new();

        public IReactiveProperty<float> CurrentProgress => _currentProgress;

        public void AddSubType(EEndurableType subType) => _subTypes.Add(subType);

        public EndurableModel(EEndurableType type, ETransformationType transformationType = ETransformationType.None)
        {
            Type = type;
            TransformationType = transformationType;
        }
    }
}