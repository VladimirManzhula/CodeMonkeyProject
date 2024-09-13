namespace Databases.EndurableModels
{
    public interface IEndurableModelsDao
    {
        EndurableModelVo[] Vos { get; }
    }
}