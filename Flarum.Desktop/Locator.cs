using Flarum.Provider;
using Flarum.Contracts.Services;
using Flarum.Services;
using Microsoft.Extensions.DependencyInjection;

using System;
using Flarum.ViewModels;
using Flarum.Desktop.Contracts.Services;
using Flarum.Desktop.Services;


namespace Flarum;

public class Locator
{
    public static Locator Instance => _Instance ?? (_Instance = new Locator());
    private static Locator _Instance;

    private IServiceProvider _services;

    public T GetService<T>()
        where T : class
    {
        if (_services.GetService(typeof(T)) is not T service)
        {
            throw new Exception($"{typeof(T)} needs to be regiestered in ConfigureServices.");
        }

        return service;
    }

    public Locator()
    {
        var _servicesCollection = new ServiceCollection();

        // Services.
        _servicesCollection.AddSingleton<INavigationService, NavigationService>();
        _servicesCollection.AddSingleton<INavigationViewService, NavigationViewService>();
        _servicesCollection.AddSingleton<IPageService, PageService>();
        _servicesCollection.AddSingleton<IDialogService, DialogService>();
        _servicesCollection.AddSingleton<IShellService, ShellService>();
        // View Models.
        _servicesCollection.AddSingleton<HomeViewModel>();
        _servicesCollection.AddSingleton<ShellViewModel>();
        _servicesCollection.AddSingleton<SettingsViewModel>();
        // Flarum Provider.
        _servicesCollection.AddSingleton<FlarumProvider>();

        _services = _servicesCollection.BuildServiceProvider();

    }

}


