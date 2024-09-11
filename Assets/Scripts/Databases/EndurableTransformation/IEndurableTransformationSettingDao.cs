namespace Databases.EndurableTransformation
{
    public interface IEndurableTransformationSettingDao
    {
        EndurableTransformationSettingVo[] Vos { get; }
    }
}