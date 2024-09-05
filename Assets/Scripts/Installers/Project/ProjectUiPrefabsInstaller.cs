﻿using SimpleUi;
using Ui.Project.Loading;
using UnityEngine;
using Zenject;

namespace Installers.Project
{
    [CreateAssetMenu(
        menuName = "Installers/Project/" + nameof(ProjectUiPrefabsInstaller),
        fileName = nameof(ProjectUiPrefabsInstaller), order = 0
    )]
    public class ProjectUiPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private LoadingView loadingView;
        
        public override void InstallBindings()
        {
            var canvasView = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasView.transform;
            
            Container.BindUiView<LoadingController, LoadingView>(loadingView, canvasTransform);
        }
    }
}