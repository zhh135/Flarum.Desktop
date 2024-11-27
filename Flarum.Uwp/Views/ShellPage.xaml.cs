using AsyncAwaitBestPractices;
using Flarum.Uwp.Contracts.Services;
using Flarum.Uwp.ViewModels;
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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Flarum.Uwp.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ShellPage : Page
    {
        private ShellViewModel ViewModel { get;}
        private ApplicationViewTitleBar TitleBar { get; }
        private CoreApplicationViewTitleBar CoreTitleBar { get; }


        public ShellPage()
        {
            InitializeComponent();

            ViewModel = new ShellViewModel();
            DataContext = ViewModel;

            Loaded += ShellPage_Loaded;

            Window.Current.SetTitleBar(TitleDragArea);

            Locator.Instance.GetService<INavigationService>().RegisterFrameEvents(ContentFrame);
            Locator.Instance.GetService<INavigationViewService>().Initialize(NavView);
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
}
