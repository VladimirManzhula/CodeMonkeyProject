using System;
using System.Collections.Generic;
using Databases.EndurableModels;

namespace Databases.RecipeSettings
{
    [Serializable]
    public struct RecipeSettingsVo
    {
        public ERecipeType type;
        public List<EEndurableType> components;
    }
}