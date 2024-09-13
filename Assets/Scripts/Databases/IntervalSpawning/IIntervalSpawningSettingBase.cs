using Databases.EndurableModels;

namespace Databases.IntervalSpawning
{
    public interface IIntervalSpawningSettingBase
    {
        IntervalSpawningSettingVo GetSetting(EEndurableType type);
    }
}