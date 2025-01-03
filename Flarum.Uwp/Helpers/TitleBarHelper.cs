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
            // TODO 不再支持 Windows.UI.ViewManagement.ApplicationView。请改用 Microsoft.UI.Windowing.AppWindow。有关更多详细信息，请参阅 https://docs.microsoft.com/en-us/windows/apps/windows-app-sdk/migrate-to-windows-app-sdk/guides/windowing。
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
