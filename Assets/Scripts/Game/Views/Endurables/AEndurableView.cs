using System;
using Game.Models.Abstract;
using Game.Models.Endurables;
using UniRx;
using UnityEngine;

namespace Game.Views.Endurables
{
    public abstract class AEndurableView : MonoBehaviour
    {
        private IDisposable _parentDisposable = Disposable.Empty;
        private IDisposable _destroyDisposable = Disposable.Empty;

        private Action _onDestroy;
        
        public void SubscribeOnParentChanged(IEndurableModel model) =>
            _parentDisposable = model.ParentTransform
                .Subscribe(OnParentChanged);
        
        public void SubscribeOnDestroy(IDestroyableModel destroyableModel, Action onDestroy = null)
        {
            _destroyDisposable = destroyableModel.IsDestroyed
                .Subscribe(OnDestroyChanged);

            _onDestroy = onDestroy;
        }

        protected virtual void OnDestroy()
        {
            _parentDisposable.Dispose();
            _destroyDisposable.Dispose();
        }

        private void OnParentChanged(Transform parent)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;
        }
        
        private void OnDestroyChanged(bool value)
        {
            if(!value)
                return;
            
            _onDestroy?.Invoke();
            Destroy(gameObject);
        }
    }
}