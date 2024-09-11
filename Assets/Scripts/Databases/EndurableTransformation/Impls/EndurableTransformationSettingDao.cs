using Core.Exceptions.Drawers;
using UnityEngine;

namespace Databases.EndurableTransformation.Impls
{
    [CreateAssetMenu(
        menuName = "Databases/" + nameof(EndurableTransformationSettingDao),
        fileName = nameof(EndurableTransformationSettingDao), order = 0
    )]
    public class EndurableTransformationSettingDao : ScriptableObject, IEndurableTransformationSettingDao
    {
        [KeyValue("from")]
        [SerializeField] private EndurableTransformationSettingVo[] vos;

        public EndurableTransformationSettingVo[] Vos => vos;
    }
}