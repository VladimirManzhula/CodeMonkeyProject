using Core.Exceptions.Drawers;
using UnityEngine;

namespace Databases.EndurableModels.Impls
{
    [CreateAssetMenu(
        menuName = "Databases/" + nameof(EndurableModelsDao),
        fileName = nameof(EndurableModelsDao), order = 0
    )]
    public class EndurableModelsDao : ScriptableObject, IEndurableModelsDao
    {
        [KeyValue("type")] 
        [SerializeField] private EndurableModelVo[] vos;

        public EndurableModelVo[] Vos => vos;
    }
}