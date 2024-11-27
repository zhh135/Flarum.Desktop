using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Flarum.Uwp.Contracts.Services;

public interface INavigationService
{
    event NavigatedEventHandler Navigated;

    bool CanGoBack
    {
        get;
    }

    void RegisterFrameEvents(Frame frame);

    void UnregisterFrameEvents();

    bool NavigateTo(string pageKey, object? parameter = null, bool clearNavigation = false);

    bool GoBack();
}
