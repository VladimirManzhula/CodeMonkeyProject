using System;
using Game.Models.Endurables;
using UniRx;
using UnityEngine;

namespace Game.Views.Endurables.Impls
{
    public class SimpleEndurableView : AEndurableView
    {
        private IDisposable _heightDisposable = Disposable.Empty;

        public void SubscribeOnHeightChanged(IEndurableModel model)
        {
            _heightDisposable = model.Height
                .Subscribe(OnHeightChanged);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _heightDisposable.Dispose();
        }

        private void OnHeightChanged(float value) => transform.localPosition = Vector3.up * value;
    }
}