using Databases.EndurableModels;

namespace Databases.CompositeEndurables.Impls
{
    public class CompositeEndurableSettingBase : ICompositeEndurableSettingBase
    {
        private readonly ICompositeEndurableSettingDao _compositeEndurableSettingDao;

        public CompositeEndurableSettingBase(ICompositeEndurableSettingDao compositeEndurableSettingDao)
        {
            _compositeEndurableSettingDao = compositeEndurableSettingDao;
        }

        public bool IsAvailableToAdd(EEndurableType goal, EEndurableType adding)
        {
            foreach (var vo in _compositeEndurableSettingDao.Vos)
            {
                if(vo.goal != goal)
                    continue;

                foreach (var availableType in vo.availableTypes)
                {
                    if(availableType != adding)
                        continue;

                    return true;
                }
            }

            return false;
        }
    }
}