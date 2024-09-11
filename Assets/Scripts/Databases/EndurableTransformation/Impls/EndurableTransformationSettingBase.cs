using Databases.EndurableModels;

namespace Databases.EndurableTransformation.Impls
{
    public class EndurableTransformationSettingBase : IEndurableTransformationSettingBase
    {
        private readonly IEndurableTransformationSettingDao _endurableTransformationSettingDao;

        public EndurableTransformationSettingBase(IEndurableTransformationSettingDao endurableTransformationSettingDao)
        {
            _endurableTransformationSettingDao = endurableTransformationSettingDao;
        }
        
        public bool TryFindTransformation(
            EEndurableType type,
            out EndurableTransformationSettingVo desiredVo
        )
        {
            foreach (var vo in _endurableTransformationSettingDao.Vos)
            {
                if (vo.from != type)
                    continue;

                desiredVo = vo;
                return true;
            }

            desiredVo = default;
            return false;
        }
    }
}