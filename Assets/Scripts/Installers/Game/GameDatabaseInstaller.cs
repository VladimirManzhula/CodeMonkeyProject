using Core.Exceptions.ZenjectUtil.Database;
using Databases.GameModels;
using Databases.GameModels.Impls;
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
        
        public override void InstallBindings()
        {
            Container.BindDatabaseWithDao<IGameModelDao, GameModelBase>(gameModelDao);
        }
    }
}