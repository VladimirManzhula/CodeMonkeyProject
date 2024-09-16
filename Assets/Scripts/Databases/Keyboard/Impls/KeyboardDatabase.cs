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
        [SerializeField] private KeyCode interactAlternative;
        
        [Header("Move")]
        [SerializeField] private KeyCode moveForward;
        [SerializeField] private KeyCode moveBack;
        [SerializeField] private KeyCode moveLeft;
        [SerializeField] private KeyCode moveRight;
        
        [Header("Menu")]
        [SerializeField] private KeyCode pause;

        public KeyCode Interact => interact;
        public KeyCode InteractAlternative => interactAlternative;
        public KeyCode MoveForward => moveForward;
        public KeyCode MoveBack => moveBack;
        public KeyCode MoveLeft => moveLeft;
        public KeyCode MoveRight => moveRight;
        public KeyCode Pause => pause;
    }
}