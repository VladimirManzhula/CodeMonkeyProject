using Databases.EndurableModels;
using Databases.EndurableTransformation;
using Game.Models.Abstract;
using UniRx;
using UnityEngine;

namespace Game.Models.Endurables
{
    public interface IEndurableModel : IDestroyableModel, IUiProgressableModel
    {
        EEndurableType Type { get; }
        
        IReactiveCollection<EEndurableType> SubTypes { get; }

        ETransformationType TransformationType { get; }

        IReactiveProperty<Transform> ParentTransform { get; }
        
        IReactiveProperty<float> Height { get; }

        void AddSubType(EEndurableType subType);
    }
}