using Databases.EndurableModels;
using UnityEngine;

namespace Game.Views.Endurables.Impls
{
    public class SybTypeEndurableView : MonoBehaviour
    {
        [SerializeField] private EEndurableType type;

        public EEndurableType Type => type;
    }
}