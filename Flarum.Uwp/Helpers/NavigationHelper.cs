using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Flarum.Uwp.Helpers
{
    public class NavigationHelper
    {
        public static string GetNavigateTo(NavigationViewItem item) => (string)item.GetValue(NavigateToProperty);

        public static void SetNavigateTo(NavigationViewItem item, string value) => item.SetValue(NavigateToProperty, value);

        public static readonly DependencyProperty NavigateToProperty =
        DependencyProperty.RegisterAttached("NavigateTo", typeof(Page), typeof(NavigationHelper), new PropertyMetadata(null));
    }
}
