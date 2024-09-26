using Databases.Audio;
using UnityEngine;

namespace Game.Services.DAO.Settings.Audio.Service
{
    public interface IAudioService
    {
        void PlaySfx(ESoundType type, Vector3 position);
    }
}