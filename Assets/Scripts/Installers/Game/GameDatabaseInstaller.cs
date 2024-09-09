using Core.Exceptions.ZenjectUtil.Database;
using Databases.CameraSettings;
using Databases.CameraSettings.Impls;
using Databases.GameModels;
using Databases.GameModels.Impls;
using Databases.Players;
using Databases.Players.Impls;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    [CreateAssetMenu(
        menuName = "Installers/Game/" + nameof(GameDatabaseInstaller),
        fileName = nameof(GameDatabaseInstaller), order = 0
    )]
    public class GameDatabaseInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private GameModelDao gameModelDao;
        [SerializeField] private PlayerSettingDao playerSettingDao;
        [SerializeField] private CameraSettingsDao cameraSettingsDao;
        
        public override void InstallBindings()
        {
            Container.BindDatabaseWithDao<IGameModelDao, GameModelBase>(gameModelDao);
            Container.BindDatabaseWithDao<IPlayerSettingDao, PlayerSettingBase>(playerSettingDao);
            Container.BindDatabaseWithDao<ICameraSettingsDao, CameraSettingsBase>(cameraSettingsDao);
        }
    }
}