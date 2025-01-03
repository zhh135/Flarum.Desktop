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

namespace Flarum.Uwp.Controls.TemplateControls
{
    public sealed partial class DiscussionControl : UserControl
    {
        private static DependencyProperty DiscussionProperty = DependencyProperty.Register(nameof(Discussion), typeof(FlarumDiscussion), typeof(DiscussionControl), new PropertyMetadata(new FlarumDiscussion()));

        public FlarumDiscussion Discussion {
            get { return (FlarumDiscussion)GetValue(DiscussionProperty); }
            set { SetValue(DiscussionProperty, value); } }

        public DiscussionControl()
        {
            this.InitializeComponent();
        }
    }
}
