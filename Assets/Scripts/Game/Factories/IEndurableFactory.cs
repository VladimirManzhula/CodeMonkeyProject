using System.Collections.Generic;
using Databases.EndurableModels;
using Game.Models.Endurables;

namespace Game.Factories
{
    public interface IEndurableFactory
    {
        IEndurableModel CreateSimple(EEndurableType type);

        IEndurableModel CreateComposite(EEndurableType mainType, List<EEndurableType> sybTypes);
    }
}