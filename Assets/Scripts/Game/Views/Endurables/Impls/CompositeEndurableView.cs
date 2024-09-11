using System;
using System.Collections.Generic;
using Databases.EndurableModels;
using Game.Models.Endurables;
using Game.Services.WorldCanvasLookAtCamera;
using Game.Ui.CompositeIngredient;
using Game.Views.InteractableObjects;
using UniRx;
using UnityEngine;

namespace Game.Views.Endurables.Impls
{
    public class CompositeEndurableView : AEndurableView, IWorldCanvasView
    {
        [SerializeField] private List<SybTypeEndurableView> sybTypeEndurableViews;
        [SerializeField] private IngredientItemCollection ingredientItemCollection;
        [SerializeField] private Canvas canvas;
        
        private IDisposable _sybTypeAddedDisposable = Disposable.Empty;
        private Func<EEndurableType, Sprite> _getSpriteByType;

        public Canvas Canvas => canvas;

        public ELookAtCameraType LookAtCameraType => ELookAtCameraType.Forward;

        public void SubscribeOnSybTypeAdded(IEndurableModel model, Func<EEndurableType, Sprite> getSpriteByType)
        {
            _sybTypeAddedDisposable = model.SubTypes.ObserveAdd()
                .Subscribe(OnSybTypeAdd);
            _getSpriteByType = getSpriteByType;
        }

        public void DisableSybTypes()
        {
            for (var index = 0; index < sybTypeEndurableViews.Count; index++)
            {
                var view = sybTypeEndurableViews[index];
                view.gameObject.SetActive(false);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _sybTypeAddedDisposable.Dispose();
        }

        private void OnSybTypeAdd(CollectionAddEvent<EEndurableType> addEvent)
        {
            var sybType = addEvent.Value;
            var spriteByType = _getSpriteByType(sybType);
            var ingredientItemView = ingredientItemCollection.Create();
            ingredientItemView.SetSprite(spriteByType);

            for (var index = 0; index < sybTypeEndurableViews.Count; index++)
            {
                var view = sybTypeEndurableViews[index];

                if (view.Type != sybType)
                    continue;

                view.gameObject.SetActive(true);
                return;
            }
        }
    }
}