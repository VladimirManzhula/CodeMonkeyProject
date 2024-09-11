using Databases.EndurableModels.Impls;

namespace Databases.EndurableModels
{
    public interface IEndurableModelsDao
    {
        EndurableModelVo[] Vos { get; }
    }
}