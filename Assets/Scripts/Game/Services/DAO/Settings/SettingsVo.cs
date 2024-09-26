using System;
using Databases.Keyboard;

namespace Game.Services.DAO.Settings
{
    [Serializable]
    public class SettingsVo
    {
        public KeyboardVo keyboardVo;
        public AudioSettingsVo audioSettingsVo;
    }
}