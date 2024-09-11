using Game.Views.InteractableObjects;
using Game.Views.InteractableObjects.Impls;
using UnityEngine;

namespace Game.Views.Levels.Impls
{
    public class LevelView : MonoBehaviour, ILevelView
    {
        [SerializeField] private AInteractableObjectView[] interactableObjectViews;

        public IInteractableObjectView[] InteractableObjectViews => interactableObjectViews;
    }
}