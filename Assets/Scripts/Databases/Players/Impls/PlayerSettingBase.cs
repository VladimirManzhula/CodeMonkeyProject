namespace Databases.Players.Impls
{
    public class PlayerSettingBase : IPlayerSettingBase
    {
        private readonly IPlayerSettingDao _playerSettingDao;

        public PlayerSettingBase(IPlayerSettingDao playerSettingDao)
        {
            _playerSettingDao = playerSettingDao;
        }

        public float Velocity => _playerSettingDao.Velocity;
    }
}