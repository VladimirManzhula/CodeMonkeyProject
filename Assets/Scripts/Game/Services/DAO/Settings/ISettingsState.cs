using Databases.Keyboard;

namespace Game.Services.DAO.Settings
{
    public interface ISettingsState
    {
        KeyboardVo KeyboardVo { get; }
        
        AudioSettingsVo GetAudioSettings();
        void SetAudioMusicSettings();
        void SetAudioSoundSettings();
    }
}