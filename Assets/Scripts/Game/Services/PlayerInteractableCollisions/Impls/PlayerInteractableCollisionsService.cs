using System;
using Game.DataHolders;
using Game.Services.InteractObjects;
using Game.Views.Player;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Services.PlayerInteractableCollisions.Impls
{
    public class PlayerInteractableCollisionsService : IPlayerInteractableCollisionsService, IInitializable, IDisposable
    {
        private readonly IInteractObjectService _interactObjectService;
        private readonly ILevelModelDataHolder _levelModelDataHolder;

        private readonly CompositeDisposable _compositeDisposable = new();
        
        public PlayerInteractableCollisionsService(
            IInteractObjectService interactObjectService,
            ILevelModelDataHolder levelModelDataHolder
        )
        {
            _interactObjectService = interactObjectService;
            _levelModelDataHolder = levelModelDataHolder;
        }

        public void Initialize()
        {
            var interactableObjectModels = _levelModelDataHolder.Model.InteractableObjectModels;

            for (var index = 0; index < interactableObjectModels.Length; index++)
            {
                var model = interactableObjectModels[index];
                
                void OnCollisionEnter(Collision collision)
                {
                    if(!collision.gameObject.TryGetComponent<PlayerView>(out _))
                        return;
            
                    _interactObjectService.AddInteractModel(model);
                }
                
                model.View.CollisionTrigger.OnCollisionEnterAsObservable()
                    .Subscribe(OnCollisionEnter)
                    .AddTo(_compositeDisposable);
                
                void OnCollisionExit(Collision collision)
                {
                    if(!collision.gameObject.TryGetComponent<PlayerView>(out _))
                        return;
            
                    _interactObjectService.RemoveInteractableModel(model);
                }

                model.View.CollisionTrigger.OnCollisionExitAsObservable()
                    .Subscribe(OnCollisionExit)
                    .AddTo(_compositeDisposable);
            }
        }

        public void Dispose() => _compositeDisposable.Dispose();
    }
}