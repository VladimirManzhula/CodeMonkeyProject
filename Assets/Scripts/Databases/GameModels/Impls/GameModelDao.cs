using Core.Exceptions.Drawers;
using Game.Views;
using UnityEngine;

namespace Databases.GameModels.Impls
{
    [CreateAssetMenu(menuName = "Databases/" + nameof(GameModelDao), fileName = nameof(GameModelDao), order = 0)]
    public class GameModelDao : ScriptableObject, IGameModelDao
    {
        [SerializeField] private LocationView locationView;
        
        [KeyValue("gameViewType")] 
        [SerializeField] private GameModelVo[] gameModelVos;
        
        public LocationView LocationView => locationView;
        public GameModelVo[] GameModelVos => gameModelVos;
    }
}