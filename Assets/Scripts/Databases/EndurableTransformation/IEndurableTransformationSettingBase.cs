using Databases.EndurableModels;

namespace Databases.EndurableTransformation
{
    public interface IEndurableTransformationSettingBase
    {
        bool TryFindTransformation(
            EEndurableType type,
            out EndurableTransformationSettingVo desiredVo
        );
    }
}