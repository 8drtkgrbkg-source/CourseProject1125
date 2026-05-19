using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.Input;
using CourseProject1125.DB;
using Tmds.DBus.Protocol;
using Microsoft.Extensions.DependencyInjection;
using Connection = CourseProject1125.DB.Connection;

namespace CourseProject1125.ViewModels
{
    public partial class MainWindowViewModel
    {
        [RelayCommand]
        private void FullExit()
        {
            System.Environment.Exit(0);
        }
    }
}