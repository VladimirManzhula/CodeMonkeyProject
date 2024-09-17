using Core.Utils.ZenjectUtil.Database;
using Databases.Audio;
using Databases.Audio.Impls;
using Databases.Keyboard;
using Databases.Keyboard.Impls;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers.Project
{
    [CreateAssetMenu(
        menuName = "Installers/Project/" + nameof(ProjectDatabaseInstaller),
        fileName = nameof(ProjectDatabaseInstaller), order = 0
    )]
    public class ProjectDatabaseInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private KeyboardDao keyboardDao;
        [SerializeField] private AudioSettingsDao audioSettingsDao;
        
        public override void InstallBindings()
        {
            Container.BindDatabaseWithDao<IKeyboardDao, KeyboardBase>(keyboardDao);
            Container.BindDatabaseWithDao<IAudioSettingsDao, AudioSettingsBase>(audioSettingsDao);
        }
    }
}