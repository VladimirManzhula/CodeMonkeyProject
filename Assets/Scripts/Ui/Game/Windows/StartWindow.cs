using Core.Constants;
using SimpleUi;
using Ui.Game.Start;

namespace Ui.Game.Windows
{
    public class StartWindow : WindowBase
    {
        public override string Name => nameof(WindowNames.EGameType.Start);
        
        protected override void AddControllers()
        {
            AddController<StartController>();
        }
    }
}