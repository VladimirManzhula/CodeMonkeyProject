using UnityEngine;
using Zenject;

namespace Installers.Project
{
    [CreateAssetMenu(
        menuName = "Installers/Project/" + nameof(ProjectDatabaseInstaller),
        fileName = nameof(ProjectDatabaseInstaller), order = 0
    )]
    public class ProjectDatabaseInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
        }
    }
}