using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.Windows.AppLifecycle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Flarum;
using Flarum.Provider;
using Flarum.Provider.Models;
using Flarum.Views;
using Flarum.Desktop.Dialogs;
using Flarum.Desktop.Contracts.Services;


namespace Flarum
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs e)
        {
            var mainInstance = Microsoft.Windows.AppLifecycle.AppInstance.FindOrRegisterForKey("main");
            var activatedEventArgs = Microsoft.Windows.AppLifecycle.AppInstance.GetCurrent().GetActivatedEventArgs();

            // If the instance that's executing the OnLaunched handler right now
            // isn't the "main" instance.
            if (!mainInstance.IsCurrent)
            {
                // Redirect the activation (and args) to the "main" instance, and exit.
                await mainInstance.RedirectActivationToAsync(activatedEventArgs);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                return;
            }

            // Initialize MainWindow here
            if (MainWindow.Instance is not null)
            {
                rootFrame =  MainWindow.Instance.Content as Frame;

                if (rootFrame is null)
                {
                    rootFrame = new Frame();
                    MainWindow.Instance.Content = rootFrame;
                    rootFrame.Navigate(typeof(SplashScreenPage));
                }
            }

            Locator.Instance.GetService<IShellService>().RegisterXamlRoot(MainWindow.Instance.Content.XamlRoot);

            Window.Activate();
            WindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(Window);
        }


        public static MainWindow Window => MainWindow.Instance;
        public static FlarumProvider CurrentProvider => (_current ??  (_current = Locator.Instance.GetService<FlarumProvider>()));
        public static IntPtr WindowHandle { get; private set; }
        public static FlarumForum CurrentForum { get; internal set; }

        private static FlarumProvider _current;

        public Frame rootFrame { get; private set; }
    }
}
