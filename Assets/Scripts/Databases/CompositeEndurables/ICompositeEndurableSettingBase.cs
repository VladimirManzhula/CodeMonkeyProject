using Databases.EndurableModels;

namespace Databases.CompositeEndurables
{
    public interface ICompositeEndurableSettingBase
    {
        bool IsAvailableToAdd(EEndurableType goal, EEndurableType adding);
    }
}