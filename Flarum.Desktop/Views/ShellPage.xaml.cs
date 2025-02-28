using AsyncAwaitBestPractices;
using Flarum.Contracts.Services;
using Flarum.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Flarum.Helpers;
using Flarum.Desktop.Views;
using Flarum.Desktop.Contracts.Services;
using WinUICommunity;


namespace Flarum.Views
{
    public sealed partial class ShellPage : ShellPageBase
    {
        public ShellPage()
        {
            InitializeComponent();

            Loaded += ShellPage_Loaded;

            App.Window.AppWindow.ExtendContentIntoTitleBar(TitleDragArea, App.Window);

            Locator.Instance.GetService<INavigationService>().RegisterFrameEvents(ContentFrame);
            Locator.Instance.GetService<INavigationViewService>().Initialize(NavView);
            // Locator.Instance.GetService<IShellService>().RegisterXamlRoot(XamlRoot);
            NavView.SelectedItem = NavView.MenuItems[0];
        }

        private async void ShellPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetDataAsync();
            ViewModel.GetDataAsync().SafeFireAndForget();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);    
            ViewModel.GetDataAsync().SafeFireAndForget();
            (App.Current as App).UnhandledException += ShellPage_UnhandledException;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            (App.Current as App).UnhandledException -= ShellPage_UnhandledException;
        }

        private void ShellPage_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            WinUICommunity.Growl.Error(
                new GrowlInfo
                {
                    ShowDateTime = true,
                    Title = "Ooops!",
                    Message = e.Message,
                    IsClosable = true
                });
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

        }
    }

    public class ShellPageBase : AppPageBase<ShellViewModel>
    {

    }
}
