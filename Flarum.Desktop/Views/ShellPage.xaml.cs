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
        }
    }
    
    public class ShellPageBase : AppPageBase<ShellViewModel>
    {

    }
}
