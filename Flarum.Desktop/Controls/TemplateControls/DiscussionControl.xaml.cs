using Flarum.Provider.Models;
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
using System.Threading.Tasks;
using Flarum.Provider;
using Windows.Graphics.Printing.PrintSupport;
using Microsoft.UI.Xaml.Media.Imaging;

namespace Flarum.Controls.TemplateControls
{
    public sealed partial class DiscussionControl : UserControl
    {
        private static DependencyProperty DiscussionProperty = DependencyProperty.Register(nameof(Discussion), typeof(FlarumDiscussion), typeof(DiscussionControl), new PropertyMetadata(new FlarumDiscussion()));

        public FlarumDiscussion Discussion {
            get { return (FlarumDiscussion)GetValue(DiscussionProperty); }
            set { SetValue(DiscussionProperty, value); } }

        private FlarumUser User { get; set; }
        private BitmapImage Avatar { get; set; }

        public DiscussionControl()
        {
            InitializeComponent();
            Loaded += DiscussionControl_Loaded;
        }

        private async void DiscussionControl_Loaded(object sender, RoutedEventArgs e)
        {
            User = await Locator.Instance.GetService<FlarumProvider>().GetFlarumUserByIdAsync(int.Parse(Discussion.User.Data.Id));
            if (User.AvatarUrl != null)
            {
                Avatar = new BitmapImage(new Uri(User.AvatarUrl));
            }
            else
            {
                Avatar = new BitmapImage();
                AutorPicture.DisplayName = User.DisplayName;
            }
        }
    }
}
