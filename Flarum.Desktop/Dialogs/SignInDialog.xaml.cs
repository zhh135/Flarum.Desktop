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



namespace Flarum.Desktop.Dialogs
{
    public sealed partial class SignInDialog : SignInDialogBase
    {
        public SignInDialog()
        {
            InitializeComponent();
        }
    }

    public partial class SignInDialogBase : DialogBase<SignInViewModel>
    {

    }
}
