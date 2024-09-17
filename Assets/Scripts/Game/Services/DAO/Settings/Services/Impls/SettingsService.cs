using Databases.Keyboard;
using Zenject;

namespace Game.Services.DAO.Settings.Services.Impls
{
    public class SettingsService : ISettingsService, IInitializable
    {
        private readonly IKeyboardBase _keyboardBase;
        private readonly ISettingsState _settingsState;

        public SettingsService(
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