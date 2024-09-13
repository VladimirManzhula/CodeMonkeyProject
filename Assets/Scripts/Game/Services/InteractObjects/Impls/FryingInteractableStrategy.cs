using System;
using Core.Providers;
using Databases.EndurableTransformation;
using Game.DataHolders;
using Game.Factories;
using Game.Models.Endurables;
using Game.Models.InteractableObjects.Impls;
using Game.Services.Exchanges;
using Game.Views.InteractableObjects.Impls;
using UniRx;

namespace Game.Services.InteractObjects.Impls
{
    public class FryingInteractableStrategy :
        AInteractableStrategy<FryingInteractableObjectView, FryingInteractableObjectModel>,
        IDisposable
    {
        private readonly IPlayerModelDataHolder _playerModelDataHolder;
        private readonly IExchangeService _exchangeService;
        private readonly IEndurableTransformationSettingBase _transformationSettingBase;
        private readonly ITimeProvider _timeProvider;
        private readonly IEndurableFactory _endurableFactory;

        public override EInteractableType Type => EInteractableType.Frying;

        private IDisposable _everyUpdateDisposable = Disposable.Empty;
        private IDisposable _endurableAppearDisposable = Disposable.Empty;

        public FryingInteractableStrategy(
            IPlayerModelDataHolder playerModelDataHolder,
            IExchangeService exchangeService,
            IEndurableTransformationSettingBase transformationSettingBase,
            ITimeProvider timeProvider,
            IEndurableFactory endurableFactory
        )
        {
            _playerModelDataHolder = playerModelDataHolder;
            _exchangeService = exchangeService;
            _transformationSettingBase = transformationSettingBase;
            _timeProvider = timeProvider;
            _endurableFactory = endurableFactory;
        }

        protected override FryingInteractableObjectModel GetModel(
            FryingInteractableObjectView view
        )
        {
            var model = new FryingInteractableObjectModel(view)
            {
                StoringTransform = view.StoringTransform
            };

            void GetInteractionAction()
            {
                var playerModel = _playerModelDataHolder.Model;
                _exchangeService.Execute(playerModel, model);
            }

            void OnEndurableChanged(IEndurableModel endurableModel)
            {
                if (endurableModel == null)
                {
                    StopFryingAnimation(view);
                    _everyUpdateDisposable.Dispose();
                    return;
                }

                var isExistTransformation = _transformationSettingBase.TryFindTransformation(endurableModel.Type, out var vo);
                
                if(!isExistTransformation || vo.transformationType != ETransformationType.Frying)
                    return;

                void OnEveryUpdate(long l)
                {
                    var deltaTime = _timeProvider.DeltaTime;
                    endurableModel.CurrentProgress.Value += deltaTime;
                    
                    if (endurableModel.CurrentProgress.Value < endurableModel.MaxProgress)
                        return;
                    
                    _everyUpdateDisposable.Dispose();
                    endurableModel.IsDestroyed.Value = true;
                    var newEndurableModel = _endurableFactory.CreateSimple(vo.to);
                    model.SetEndurableModel(newEndurableModel);
                    StopFryingAnimation(view);
                }
                
                view.PlayFryingAnimation();
                view.SubscribeOnProgress(model.EndurableModel.Value);
                _everyUpdateDisposable = Observable.EveryUpdate().Subscribe(OnEveryUpdate);
            }

            model.ExecutingAction = GetInteractionAction;
            _endurableAppearDisposable = model.EndurableModel
                .Subscribe(OnEndurableChanged);
            return model;
        }

        public void Dispose()
        {
            _everyUpdateDisposable.Dispose();
            _endurableAppearDisposable.Dispose();
        }

        private static void StopFryingAnimation(FryingInteractableObjectView view)
        {
            view.DisableProgressBar();
            view.StopFryingAnimation();
        }
    }
}