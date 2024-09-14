using Core.Exceptions.ZenjectUtil.Database;
using Databases.Audio;
using Databases.Audio.Impls;
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
        [SerializeField] private AudioSettingsDao audioSettingsDao;
        
        public override void InstallBindings()
        {
            Container.BindDatabase<IKeyboardDatabase>(keyboardDatabase);
            Container.BindDatabaseWithDao<IAudioSettingsDao, AudioSettingsBase>(audioSettingsDao);
        }
    }
}