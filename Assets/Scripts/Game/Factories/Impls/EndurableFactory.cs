using System.Collections.Generic;
using Databases.EndurableModels;
using Databases.EndurableTransformation;
using Game.Models.Endurables;
using Game.Models.Endurables.Impls;
using Game.Services.WorldCanvasLookAtCamera;
using Game.Views.Endurables;
using Game.Views.Endurables.Impls;
using Zenject;

namespace Game.Factories.Impls
{
    public class EndurableFactory : IEndurableFactory
    {
        private readonly IEndurableModelsBase _endurableModelsBase;
        private readonly IEndurableTransformationSettingBase _transformationSettingDatabase;
        private readonly IWorldCanvasLookAtCameraService _worldCanvasLookAtCameraService;
        private readonly DiContainer _container;

        public EndurableFactory(
            IEndurableModelsBase endurableModelsBase,
            IEndurableTransformationSettingBase transformationSettingDatabase,
            IWorldCanvasLookAtCameraService worldCanvasLookAtCameraService,
            DiContainer container
        )
        {
            _endurableModelsBase = endurableModelsBase;
            _transformationSettingDatabase = transformationSettingDatabase;
            _worldCanvasLookAtCameraService = worldCanvasLookAtCameraService;
            _container = container;
        }

        public IEndurableModel CreateSimple(EEndurableType type)
        {
            var model = GetModel<SimpleEndurableView>(type, out var view);
            view.SubscribeOnDestroy(model);
            view.SubscribeOnHeightChanged(model);

            if (_transformationSettingDatabase.TryFindTransformation(type, out var vo))
            {
                model.CurrentProgress.Value = 0;
                model.MaxProgress = vo.countInteractions;
                model.TransformationType = vo.transformationType;
            }

            return model;
        }

        public IEndurableModel CreateComposite(EEndurableType mainType, List<EEndurableType> sybTypes)
        {
            var model = GetModel<CompositeEndurableView>(mainType, out var view);
            
            void OnCompositeDestroy() => _worldCanvasLookAtCameraService.Remove(view);
            
            view.SubscribeOnDestroy(model, OnCompositeDestroy);
            view.DisableSybTypes();
            view.SubscribeOnSybTypeAdded(model, _endurableModelsBase.GetSpriteByType);
            _worldCanvasLookAtCameraService.Add(view);

            foreach (var sybType in sybTypes)
                model.AddSubType(sybType);

            return model;
        }

        private EndurableModel GetModel<TEndurableView>(EEndurableType type, out TEndurableView view)
            where TEndurableView : AEndurableView
        {
            var foodPrefab = _endurableModelsBase.GetObjectByType<TEndurableView>(type);
            view = _container.InstantiatePrefabForComponent<TEndurableView>(foodPrefab);
            var endurableModel = new EndurableModel(type);
            view.SubscribeOnDestroy(endurableModel);
            view.SubscribeOnParentChanged(endurableModel);
            return endurableModel;
        }
    }
}