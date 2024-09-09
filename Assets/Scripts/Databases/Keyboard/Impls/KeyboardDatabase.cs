using UnityEngine;

namespace Databases.Keyboard.Impls
{
    [CreateAssetMenu(
        menuName = "Databases/" + nameof(KeyboardDatabase),
        fileName = nameof(KeyboardDatabase), order = 0
    )]
    public class KeyboardDatabase : ScriptableObject, IKeyboardDatabase
    {
        [Header("Control")]
        [SerializeField] private KeyCode interact;
        
        [Header("Move")]
        [SerializeField] private KeyCode moveForward;
        [SerializeField] private KeyCode moveBack;
        [SerializeField] private KeyCode moveLeft;
        [SerializeField] private KeyCode moveRight;

        public KeyCode Interact => interact;
        public KeyCode MoveForward => moveForward;
        public KeyCode MoveBack => moveBack;
        public KeyCode MoveLeft => moveLeft;
        public KeyCode MoveRight => moveRight;
    }
}