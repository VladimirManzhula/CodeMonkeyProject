using Core.Constants;
using SimpleUi;
using Ui.Menu.Settings;

namespace Ui.Menu.Windows
{
    public class SettingsWindow : WindowBase
    {
        public override string Name => nameof(WindowNames.EMenuType.Settings);
        
        protected override void AddControllers()
        {
            AddController<SettingsController>();
        }
    }
}