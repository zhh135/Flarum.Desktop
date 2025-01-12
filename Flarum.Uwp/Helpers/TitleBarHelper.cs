using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace Flarum.Uwp.Helpers
{
    public static class TitleBarHelper
    {
        public static void ExtendContentIntoTitleBar(this AppWindow appWindow, UIElement AppTitleBar, Window Window)
        {
            var TitleBar = appWindow.TitleBar;

            TitleBar.BackgroundColor = Colors.Transparent;
            TitleBar.ButtonBackgroundColor = Colors.Transparent;
            TitleBar.ButtonHoverBackgroundColor = Colors.Transparent;
            TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            TitleBar.ButtonPressedBackgroundColor = Colors.Transparent;

            Window.ExtendsContentIntoTitleBar = true;
            TitleBar.ExtendsContentIntoTitleBar = true;
            Window.SetTitleBar(AppTitleBar);
        }
    }
}
