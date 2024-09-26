using System;
using Databases.Audio;
using Databases.EndurableTransformation;
using Game.DataHolders;
using Game.Factories;
using Game.Models.Endurables;
using Game.Models.InteractableObjects.Impls;
using Game.Services.DAO.Settings.Audio.Service;
using Game.Services.Exchanges;
using Game.Views.InteractableObjects.Impls;
using UniRx;

namespace Game.Services.InteractObjects.Impls
{
    public class CuttingInteractableStrategy : AInteractableStrategy<CuttingInteractableObjectView,
        CuttingInteractableObjectModel>, IDisposable
    {
        private readonly IPlayerModelDataHolder _playerModelDataHolder;
        private readonly IExchangeService _exchangeService;
        private readonly IEndurableFactory _endurableFactory;
        private readonly IEndurableTransformationSettingBase _transformationSettingBase;
        private readonly IAudioService _audioService;

        public override EInteractableType Type => EInteractableType.Cutting;

        private IDisposable _endurableAppearDisposable = Disposable.Empty;

        public CuttingInteractableStrategy(
            IPlayerModelDataHolder playerModelDataHolder,
            IExchangeService exchangeService,
            IEndurableFactory endurableFactory,
            IEndurableTransformationSettingBase endurableTransformationSettingBase,
            IAudioService audioService
        )
        {
            _playerModelDataHolder = playerModelDataHolder;
            _exchangeService = exchangeService;
            _endurableFactory = endurableFactory;
            _transformationSettingBase = endurableTransformationSettingBase;
            _audioService = audioService;
        }

        protected override CuttingInteractableObjectModel GetModel(CuttingInteractableObjectView view)
        {
            var cuttingModel = new CuttingInteractableObjectModel(view)
            {
                StoringTransform = view.StoringTransform
            };

            void GetInteractionAction()
            {
                var playerModel = _playerModelDataHolder.Model;
                _exchangeService.Execute(playerModel, cuttingModel);
            }

            void GetAlternativeInteraction()
            {
                _audioService.PlaySfx(ESoundType.Chop, view.transform.position);
                var endurableModel = cuttingModel.EndurableModel.Value;
                var endurableType = endurableModel.Type;
                var isExistTransformation = _transformationSettingBase.TryFindTransformation(
                    endurableType,
                    out var vo
                );

                if (!isExistTransformation || vo.transformationType != ETransformationType.Cutting)
                    return;

                endurableModel.CurrentProgress.Value++;

                if (endurableModel.CurrentProgress.Value < endurableModel.MaxProgress)
                    return;

                endurableModel.IsDestroyed.Value = true;
                var newEndurableModel = _endurableFactory.CreateSimple(vo.to);
                cuttingModel.SetEndurableModel(newEndurableModel);
            }

            void OnEndurableChanged(IEndurableModel endurableModel)
            {
                if (endurableModel == null || endurableModel.TransformationType != ETransformationType.Cutting)
                {
                    view.DisableProgressBar();
                    return;
                }

                view.SubscribeOnProgress(cuttingModel.EndurableModel.Value);
            }

            cuttingModel.ExecutingAction = GetInteractionAction;
            cuttingModel.AlternativeExecutingAction = GetAlternativeInteraction;
            _endurableAppearDisposable = cuttingModel.EndurableModel.Subscribe(OnEndurableChanged);
            return cuttingModel;
        }

        public void Dispose() => _endurableAppearDisposable.Dispose();
    }
}