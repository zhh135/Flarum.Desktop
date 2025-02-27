using System.Diagnostics.CodeAnalysis;


using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System;
using System.Linq;
using Flarum.Contracts.Services;
using Flarum.Helpers;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;
using Flarum.Desktop.Contracts.Services;

namespace Flarum.Services;

public class NavigationViewService : INavigationViewService
{
    private readonly INavigationService _navigationService;

    private readonly IPageService _pageService;

    private readonly IDialogService _dialogService;

    private NavigationView? _navigationView;

    public IList<object>? MenuItems => _navigationView?.MenuItems;

    public object? SettingsItem => _navigationView?.SettingsItem;

    public NavigationView NavView { get => _navigationView; }

    public NavigationViewService(INavigationService navigationService, IPageService pageService, IDialogService dialogService)
    {
        _navigationService = navigationService;
        _pageService = pageService;
        _dialogService = dialogService;
    }

    
    public void Initialize(NavigationView navigationView)
    {
        _navigationView = navigationView;
        _navigationView.BackRequested += OnBackRequested;
        _navigationView.SelectionChanged += OnSelectionChanged;
    }

    public void UnregisterEvents()
    {
        if (_navigationView != null)
        {
            _navigationView.BackRequested -= OnBackRequested;
            _navigationView.SelectionChanged -= OnSelectionChanged;
        }
    }

    public NavigationViewItem? GetSelectedItem(Type pageType)
    {
        if (_navigationView != null)
        {
            return GetSelectedItem(_navigationView.MenuItems, pageType) ?? GetSelectedItem(_navigationView.FooterMenuItems, pageType);
        }

        return null;
    }

    private void OnBackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args) => _navigationService.GoBack();

    private void OnSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.IsSettingsSelected)
        {
            var abab =  _navigationService.NavigateTo("SettingsPage");
            if (abab) Debug.WriteLine("Settings Page is navigated!");
        }
        else if(((NavigationViewItem)args.SelectedItem).Tag?.ToString() == "SignIn")
        {
            var dialog = _dialogService.GetDialog("SignInDialog");
            dialog.XamlRoot = MainWindow.Instance.Content.XamlRoot;
            //_ = dialog.ShowAsync();
            throw new Exception("abab");
        }
        else
        {
            var selectedItem = args.SelectedItem as NavigationViewItem;

            if (selectedItem?.GetValue(NavigationHelper.NavigateToProperty) is string pageKey)
            {
                _navigationService.NavigateTo(pageKey);
            }

            Debug.WriteLine("Navigate!");
        }
    }

    private NavigationViewItem? GetSelectedItem(IEnumerable<object> menuItems, Type pageType)
    {
        foreach (var item in menuItems.OfType<NavigationViewItem>())
        {
            if (IsMenuItemForPageType(item, pageType))
            {
                return item;
            }

            var selectedChild = GetSelectedItem(item.MenuItems, pageType);
            if (selectedChild != null)
            {
                return selectedChild;
            }
        }

        return null;
    }

    private bool IsMenuItemForPageType(NavigationViewItem menuItem, Type sourcePageType)
    {
        if (menuItem.GetValue(NavigationHelper.NavigateToProperty) is string pageKey)
        {
            return _pageService.GetPageType(pageKey) == sourcePageType;
        }

        return false;
    }

}
