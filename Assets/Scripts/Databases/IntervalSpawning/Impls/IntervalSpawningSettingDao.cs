using Core.Utils.Drawers;
using UnityEngine;

namespace Databases.IntervalSpawning.Impls
{
    [CreateAssetMenu(
        menuName = "Databases/" + nameof(IntervalSpawningSettingDao),
        fileName = nameof(IntervalSpawningSettingDao), order = 0
    )]
    public class IntervalSpawningSettingDao : ScriptableObject, IIntervalSpawningSettingDao
    {
        [KeyValue("type")]
        [SerializeField] private IntervalSpawningSettingVo[] vos;
        
        public IntervalSpawningSettingVo[] Vos => vos;
    }
}