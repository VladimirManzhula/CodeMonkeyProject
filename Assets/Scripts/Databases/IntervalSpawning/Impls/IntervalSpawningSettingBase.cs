using System;
using Databases.EndurableModels;

namespace Databases.IntervalSpawning.Impls
{
    public class IntervalSpawningSettingBase : IIntervalSpawningSettingBase
    {
        private readonly IIntervalSpawningSettingDao _intervalSpawningSettingDao;

        public IntervalSpawningSettingBase(IIntervalSpawningSettingDao intervalSpawningSettingDao)
        {
            _intervalSpawningSettingDao = intervalSpawningSettingDao;
        }
        
        public IntervalSpawningSettingVo GetSetting(EEndurableType type)
        {
            foreach (var vo in _intervalSpawningSettingDao.Vos)
            {
                if (vo.type != type)
                    continue;

                return vo;
            }

            throw new Exception($"{nameof(IntervalSpawningSettingVo)} Doesn't exist settings with type : {type}");
        }
    }
}