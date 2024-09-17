using Core.Utils.DAO.Impls;

namespace Game.Services.DAO.Settings.Impls
{
    public class SettingsDao : ALocalStorageJsonDao<SettingsVo>, ISettingsDao
    {
        public SettingsDao(string fileName) : base(fileName)
        {
        }
    }
}