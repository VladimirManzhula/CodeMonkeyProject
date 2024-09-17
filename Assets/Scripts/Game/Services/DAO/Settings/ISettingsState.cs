using Databases.Keyboard;
using Databases.Keyboard.Impls;

namespace Game.Services.DAO.Settings
{
    public interface ISettingsState
    {
        KeyboardVo KeyboardVo { get; }
    }
}