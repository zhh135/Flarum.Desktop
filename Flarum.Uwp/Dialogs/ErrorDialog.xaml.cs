using Flarum.Provider;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;


namespace Flarum.Desktop.Dialogs
{
    public sealed partial class ErrorDialog : ContentDialog
    {
        private string Meassage { get; set; }
        private string Url => Locator.Instance.GetService<FlarumProvider>().Option.Url;

        public ErrorDialog()
        {
            this.InitializeComponent();
        }

        public async Task<ContentDialogResult> ShowDialogWithMeassageAsync(string Meassage)
        {
            this.Meassage = Meassage;
            var Result = await this.ShowAsync();
            return Result;
        }
    }
}
