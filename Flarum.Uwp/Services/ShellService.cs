using Flarum.Desktop.Contracts.Services;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flarum.Desktop.Services
{
    public class ShellService : IShellService
    {
        private XamlRoot ShellXamlRoot { get; set; }

        public XamlRoot GetCurrentXamlRoot()
        {
            return ShellXamlRoot;
        }

        public void RegisterXamlRoot(XamlRoot xamlRoot)
        {
            ShellXamlRoot = xamlRoot;
        }

        public void UnregisterXamlRoot()
        {
            ShellXamlRoot = null;
        }
    }
}
