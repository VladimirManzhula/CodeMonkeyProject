using Databases.Keyboard;
using Zenject;

namespace Game.Services.DAO.Settings.Keyboard.Services.Impls
{
    public class KeyboardService : IKeyboardService, IInitializable
    {
        private readonly IKeyboardBase _keyboardBase;
        private readonly ISettingsState _settingsState;

        public KeyboardService(
            IKeyboardBase keyboardBase,
            ISettingsState settingsState
        )
        {
            _keyboardBase = keyboardBase;
            _settingsState = settingsState;
        }
        
        public void Initialize()
        {
            _keyboardBase.SetKeyboard(_settingsState.KeyboardVo);
        }
    }
}