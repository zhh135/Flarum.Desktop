﻿using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flarum.Desktop.Contracts.Services
{
    public interface IDialogService
    {
        ContentDialog GetDialog(string Key);
    }
}
