﻿using Core.Constants;
using SimpleUi;
using Ui.Menu.Menu;

namespace Ui.Menu.Windows
{
    public class MenuWindow : WindowBase
    {
        public override string Name => nameof(WindowNames.EMenuType.Menu);
        
        protected override void AddControllers()
        {
            AddController<MenuController>();
        }
    }
}