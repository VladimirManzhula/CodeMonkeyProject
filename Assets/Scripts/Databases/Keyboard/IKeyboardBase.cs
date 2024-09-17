using Databases.Keyboard.Impls;

namespace Databases.Keyboard
{
    public interface IKeyboardBase
    {
        KeyboardVo KeyboardVo { get; }
        
        void SetKeyboard(KeyboardVo keyboardVo);
    }
}