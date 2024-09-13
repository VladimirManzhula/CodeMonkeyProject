using System;
using Game.Models.Abstract;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Components
{
    public class UiProgressableComponent : MonoBehaviour
    {
        [SerializeField] private Image progressImage;
        [SerializeField] private GameObject progressBarContainer;

        private IDisposable _progressDisposable = Disposable.Empty;

        public void Subscribe(IUiProgressableModel model)
        {
            void OnProgressChanged(float value)
            {
                progressBarContainer.SetActive(value != 0);
                progressImage.fillAmount = value / model.MaxProgress;
            }

            _progressDisposable = model.CurrentProgress
                .Subscribe(OnProgressChanged);
        }

        public void DisableProgressBar() => progressBarContainer.SetActive(false);

        private void OnDestroy() => _progressDisposable.Dispose();
    }
}