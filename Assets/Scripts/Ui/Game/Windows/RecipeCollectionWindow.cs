using Core.Constants;
using SimpleUi;
using Ui.Game.RecipeCollection;
using Ui.Menu.Menu;

namespace Ui.Game.Windows
{
    public class RecipeCollectionWindow : WindowBase
    {
        public override string Name => nameof(WindowNames.EGameType.Recipe);

        protected override void AddControllers()
        {
            AddController<RecipeCollectionController>();
        }
    }
}