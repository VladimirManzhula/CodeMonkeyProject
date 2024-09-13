using Core.Exceptions.Drawers;
using UnityEngine;

namespace Databases.CompositeEndurables.Impls
{
    [CreateAssetMenu(
        menuName = "Databases/" + nameof(CompositeEndurableSettingDao),
        fileName = nameof(CompositeEndurableSettingDao), order = 0
    )]
    public class CompositeEndurableSettingDao : ScriptableObject, ICompositeEndurableSettingDao
    {
        [KeyValue("goal")]
        [SerializeField] private CompositeEndurableSettingVo[] vos;
        
        public CompositeEndurableSettingVo[] Vos => vos;
    }
}