using Core.Constants;
using SimpleUi;
using SimpleUi.Interfaces;
using Ui.Game.Pause;

namespace Ui.Game.Windows
{
    public class PauseWindow : WindowBase, IPopUp, INoneHidden
    {
        public override string Name => nameof(WindowNames.EGameType.Pause);
        
        protected override void AddControllers()
        {
            AddController<PauseController>();
        }
    }
}