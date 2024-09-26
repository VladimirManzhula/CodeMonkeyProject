using Game.Services.DAO.Settings.Audio.Sounds.Impls;

namespace Databases.Audio
{
    public interface IAudioSettingsDao
    {
        SoundsPlayer SoundsPlayer { get; }
        SoundSettingsVo[] Vos { get; }
    }
}