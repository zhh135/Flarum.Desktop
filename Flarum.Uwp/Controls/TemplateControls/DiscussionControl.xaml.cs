using Flarum.Provider.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Flarum.Uwp.Controls.TemplateControls
{
    public sealed partial class DiscussionControl : UserControl
    {
        private static DependencyProperty DiscussionProperty = DependencyProperty.Register(nameof(Discussion), typeof(FlarumDiscussion), typeof(DiscussionControl), new PropertyMetadata(new FlarumDiscussion()));

        public FlarumDiscussion Discussion {
            get { return (FlarumDiscussion)GetValue(DiscussionProperty)}
            set { SetValue(DiscussionProperty, value)} }

        public DiscussionControl()
        {
            this.InitializeComponent();
        }
    }
}
