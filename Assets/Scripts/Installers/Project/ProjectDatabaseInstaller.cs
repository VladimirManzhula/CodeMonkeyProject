using Core.Exceptions.ZenjectUtil.Database;
using Databases.Keyboard;
using Databases.Keyboard.Impls;
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
        [SerializeField] private KeyboardDatabase keyboardDatabase;
        
        public override void InstallBindings()
        {
            Container.BindDatabase<IKeyboardDatabase>(keyboardDatabase);
        }
    }
}