﻿using Core.Services.Scenes.Impls;
using Project.Windows;
using Zenject;

namespace Installers.Project
{
    public class ProjectInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            SetSettings();
            BindServices();
            BindWindows();
        }

        private void SetSettings()
        {
            SignalBusInstaller.Install(Container); 
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<SceneService>().AsSingle();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<LoadingWindow>().AsSingle();
        }
    }
}