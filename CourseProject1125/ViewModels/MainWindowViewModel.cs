using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CourseProject1125.DB;
using Tmds.DBus.Protocol;
using Microsoft.Extensions.DependencyInjection;
using Connection = CourseProject1125.DB.Connection;

namespace CourseProject1125.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
       

        public MainWindowViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
               
                string connectionString = Connection.ConnectionString; 

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}