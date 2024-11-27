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
        public static void ExtendContentIntoTitleBar()
        {
            var TitleBar = ApplicationView.GetForCurrentView().TitleBar;
            var CoreTitleBar = CoreApplication.GetCurrentView().TitleBar;

            TitleBar.BackgroundColor = Colors.Transparent;
            TitleBar.ButtonBackgroundColor = Colors.Transparent;
            TitleBar.ButtonHoverBackgroundColor = Colors.Transparent;
            TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            TitleBar.ButtonPressedBackgroundColor = Colors.Transparent;

            CoreTitleBar.ExtendViewIntoTitleBar = true;
        }
    }
}
