using Core.Utils.ZenjectUtil.Database;
using Databases.CameraSettings;
using Databases.CameraSettings.Impls;
using Databases.CompositeEndurables;
using Databases.CompositeEndurables.Impls;
using Databases.EndurableModels;
using Databases.EndurableModels.Impls;
using Databases.EndurableTransformation;
using Databases.EndurableTransformation.Impls;
using Databases.GameModels;
using Databases.GameModels.Impls;
using Databases.IntervalSpawning;
using Databases.IntervalSpawning.Impls;
using Databases.Players;
using Databases.Players.Impls;
using Databases.RecipeSettings;
using Databases.RecipeSettings.Impls;
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
        [SerializeField] private EndurableModelsDao endurableModelsDao;
        [SerializeField] private EndurableTransformationSettingDao endurableTransformationSettingDao;
        [SerializeField] private CompositeEndurableSettingDao compositeEndurableSettingDao;
        [SerializeField] private RecipeSettingsDao recipeSettingsDao;
        [SerializeField] private IntervalSpawningSettingDao intervalSpawningSettingDao;
        
        public override void InstallBindings()
        {
            Container.BindDatabaseWithDao<IGameModelDao, GameModelBase>(gameModelDao);
            Container.BindDatabaseWithDao<IPlayerSettingDao, PlayerSettingBase>(playerSettingDao);
            Container.BindDatabaseWithDao<ICameraSettingsDao, CameraSettingsBase>(cameraSettingsDao);
            Container.BindDatabaseWithDao<IEndurableModelsDao, EndurableModelsBase>(endurableModelsDao);
            Container.BindDatabaseWithDao<IEndurableTransformationSettingDao, EndurableTransformationSettingBase>(endurableTransformationSettingDao);
            Container.BindDatabaseWithDao<ICompositeEndurableSettingDao, CompositeEndurableSettingBase>(compositeEndurableSettingDao);
            Container.BindDatabaseWithDao<IRecipeSettingsDao, RecipeSettingsBase>(recipeSettingsDao);
            Container.BindDatabaseWithDao<IIntervalSpawningSettingDao, IntervalSpawningSettingBase>(intervalSpawningSettingDao);
        }
    }
}