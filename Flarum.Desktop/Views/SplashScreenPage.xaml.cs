using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.ApplicationModel.Activation;
using Windows.UI.Core;
using Flarum.Helpers;
using Flarum.Desktop.Contracts.Services;
using Flarum.Provider;
using System.Diagnostics;

namespace Flarum.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SplashScreenPage : Page
    {
        public SplashScreenPage()
        {
            InitializeComponent();
            App.Window.ExtendsContentIntoTitleBar = true;

        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            /*
            var provider = Locator.Instance.GetService<FlarumProvider>();

            provider.Option.Url = "https://discuss.flarum.org.cn";
            App.CurrentForum = await provider.GetFlarumForumAsync();
            Debug.WriteLine($"Load succeed! Url:{provider.Option.Url}");
            */
            DismissExtendedSplash();
        }

        public void DismissExtendedSplash()
        {
            var rootFrame = new Frame();
            rootFrame.Navigate(typeof(ShellPage));
            App.Window.Content = rootFrame;
        }
    }
}
