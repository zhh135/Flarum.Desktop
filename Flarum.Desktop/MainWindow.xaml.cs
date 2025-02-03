using Flarum.ViewModels;
using Flarum.Views;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinRT.Interop;


namespace Flarum
{
    public sealed partial class MainWindow : Window
    {
        public static MainWindow Instance => _Instance ?? (_Instance = new MainWindow());
        private static MainWindow _Instance;

        private ShellViewModel ViewModel { get; }

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = Locator.Instance.GetService<ShellViewModel>();
            Debug.WriteLine("Hello");
        }

        
    }
}
