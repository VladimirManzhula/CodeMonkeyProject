namespace Databases.Keyboard.Impls
{
    public class KeyboardBase : IKeyboardBase
    {
        private readonly IKeyboardDao _keyboardDao;

        public KeyboardBase(IKeyboardDao keyboardDao)
        {
            _keyboardDao = keyboardDao;
        }

        public KeyboardVo KeyboardVo => _keyboardDao.KeyboardVo;
        
        public void SetKeyboard(KeyboardVo keyboardVo) => _keyboardDao.KeyboardVo = keyboardVo;
    }
}