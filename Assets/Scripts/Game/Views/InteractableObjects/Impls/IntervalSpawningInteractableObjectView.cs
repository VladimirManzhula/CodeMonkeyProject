using Databases.EndurableModels;
using Game.Services.InteractObjects;
using UnityEngine;

namespace Game.Views.InteractableObjects.Impls
{
    public class IntervalSpawningInteractableObjectView : AInteractableObjectView
    {
        [SerializeField] private Transform startSpawningPoint;
        [SerializeField] private EEndurableType spawningObject;
        
        public override EInteractableType Type => EInteractableType.IntervalSpawning;

        public Transform StartSpawningPoint => startSpawningPoint;

        public EEndurableType SpawningObject => spawningObject;
    }
}