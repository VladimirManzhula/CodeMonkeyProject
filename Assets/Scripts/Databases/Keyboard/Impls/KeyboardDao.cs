using UnityEngine;

namespace Databases.Keyboard.Impls
{
    [CreateAssetMenu(
        menuName = "Databases/" + nameof(KeyboardDao),
        fileName = nameof(KeyboardDao), order = 0
    )]
    public class KeyboardDao : ScriptableObject, IKeyboardDao
    {
        [SerializeField] private KeyboardVo keyboardVo;

        public KeyboardVo KeyboardVo
        {
            get => keyboardVo;
            set => keyboardVo = value;
        }
    }
}