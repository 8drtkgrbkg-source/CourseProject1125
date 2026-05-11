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
        private DataView _allBooks;

        
        public DataView AllBooks
        {
            get => _allBooks;
            set
            {
                _allBooks = value;
                OnPropertyChanged(); 
            }
        }

        public MainWindowViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
               
                string connectionString = Connection.ConnectionString; 

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    
                    string query = "SELECT * FROM books"; 
                    
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    AllBooks = dt.DefaultView;
                }
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