using Flarum.Provider;
using Flarum.Uwp.Contracts.Services;
using Flarum.Uwp.Services;
using Microsoft.Extensions.DependencyInjection;

using System;


namespace Flarum.Uwp;

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
        _servicesCollection.AddSingleton<INavigationService, NavigationService>();
        _servicesCollection.AddSingleton<INavigationViewService, NavigationViewService>();
        _servicesCollection.AddSingleton<IPageService, PageService>();
        _servicesCollection.AddSingleton<FlarumProvider>();
        _services = _servicesCollection.BuildServiceProvider();

    }

}


