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
using Flarum.Desktop.ViewModels;
using AsyncAwaitBestPractices;
using Flarum.Provider.Models;
using Flarum.Contracts.Services;


namespace Flarum.Desktop.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DiscussionPage : DiscussionPageBase
    {
        public DiscussionPage()
        {
            InitializeComponent();
            Locator.Instance.GetService<INavigationViewService>().NavView.SelectedItem = null;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ViewModel.Id = int.Parse(((FlarumDiscussion) e.Parameter).Id);
            ViewModel.GetDataAsync().SafeFireAndForget();
        }
    }

    public class DiscussionPageBase : AppPageBase<DiscussionViewModel>
    {

    }
}
