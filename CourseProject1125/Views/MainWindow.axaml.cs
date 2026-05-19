using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CourseProject1125.Views;
using Microsoft.Data.SqlClient;
using MySqlConnector;

namespace CourseProject1125.Views;

public partial class MainWindow : Window
{
    private string connectionString = "Server=127.0.0.1;Database=CourseProject1125;Uid=root;Pwd=;";
    
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void BtnLogin_Click(object sender, RoutedEventArgs e)
      {
          var loginInput = this.FindControl<TextBox>("TxtLogin")?.Text?.Trim();
          var passwordInput = this.FindControl<TextBox>("TxtPassword")?.Text?.Trim();
          
          try
          {
              using (var conn = new MySqlConnection(connectionString))
              {
                  conn.Open();
                  string sql = "SELECT role_id FROM users WHERE BINARY login = @login AND password_hash = @pass LIMIT 1";

                  using (var cmd = new MySqlCommand(sql, conn))
                  {
                      cmd.Parameters.AddWithValue("@login", loginInput);
                      cmd.Parameters.AddWithValue("@pass", passwordInput);
                      
                      var result = cmd.ExecuteScalar();
                      if (result != null && result != DBNull.Value)
                      {
                          int roleId = Convert.ToInt32(result);
                          NavigateByRole(roleId);
                      }
                  }
              }
          }
          catch (Exception ex)
          {
          }
      }


        private void NavigateByRole(int roleId)
        {
            Window nextWindow = null;
            switch (roleId)
            {
                case 1: 
                    nextWindow = new AdminWindow();
                    break;
                case 2: 
                    nextWindow = new LibrarianWindow();
                    break;
                case 3: 
                    nextWindow = new ReaderWindow();
                    break;
            }
            
            if (nextWindow != null)
            {
                nextWindow.Show();
                this.Close(); 
            }
        }
}