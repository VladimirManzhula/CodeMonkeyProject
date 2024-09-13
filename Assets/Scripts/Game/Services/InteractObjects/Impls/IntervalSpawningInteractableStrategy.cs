using System;
using Databases.IntervalSpawning;
using Game.DataHolders;
using Game.Factories;
using Game.Models.InteractableObjects.Impls;
using Game.Services.Exchanges;
using Game.Views.InteractableObjects.Impls;
using UniRx;

namespace Game.Services.InteractObjects.Impls
{
    public class IntervalSpawningInteractableStrategy : AInteractableStrategy<IntervalSpawningInteractableObjectView,
        IntervalSpawningInteractableObjectModel>, IDisposable
    {
        private readonly IIntervalSpawningSettingBase _intervalSpawningSettingBase;
        private readonly IExchangeService _exchangeService;
        private readonly IPlayerModelDataHolder _playerModelDataHolder;
        private readonly IEndurableFactory _endurableFactory;
        public override EInteractableType Type => EInteractableType.IntervalSpawning;

        private IDisposable _intervalDisposable = Disposable.Empty;

        public IntervalSpawningInteractableStrategy(
            IIntervalSpawningSettingBase intervalSpawningSettingBase,
            IExchangeService exchangeService,
            IPlayerModelDataHolder playerModelDataHolder,
            IEndurableFactory endurableFactory
        )
        {
            _intervalSpawningSettingBase = intervalSpawningSettingBase;
            _exchangeService = exchangeService;
            _playerModelDataHolder = playerModelDataHolder;
            _endurableFactory = endurableFactory;
        }

        protected override IntervalSpawningInteractableObjectModel GetModel(
            IntervalSpawningInteractableObjectView view
        )
        {
            var model = new IntervalSpawningInteractableObjectModel(view)
            {
                StartSpawnPoint = view.StartSpawningPoint
            };

            var vo = _intervalSpawningSettingBase.GetSetting(view.SpawningObject);

            void OnInterval(long l)
            {
                var modelsCount = model.ModelsCount;
                
                if(modelsCount >= vo.maxCount)
                    return;

                var endurableModel = _endurableFactory.CreateSimple(view.SpawningObject);
                model.SetEndurableModel(endurableModel);
            }

            void GetInteractableAction()
            {
                var playerModel = _playerModelDataHolder.Model;
                _exchangeService.Execute(playerModel,model);
            }

            _intervalDisposable = Observable.Interval(TimeSpan.FromSeconds(vo.interval))
                .Subscribe(OnInterval);
            model.ExecutingAction = GetInteractableAction;
            return model;
        }

        public void Dispose() => _intervalDisposable.Dispose();
    }
}