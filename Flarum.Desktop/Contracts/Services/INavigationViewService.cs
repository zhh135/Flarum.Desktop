using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;

namespace Flarum.Contracts.Services;

public interface INavigationViewService
{
    public NavigationView NavView { get;}
    IList<object>? MenuItems
    {
        get;
    }

    object? SettingsItem
    {
        get;
    }

    void Initialize(NavigationView navigationView);

    void UnregisterEvents();

    NavigationViewItem? GetSelectedItem(Type pageType);
}
