using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CourseProject1125.Views;
using Microsoft.Data.SqlClient;
using MySqlConnector;

namespace CourseProject1125.Views;

public partial class MainAppWindow : Window
{
    
    private string connectionString = "Server=localhost:3306;Database=CourseProject1125;Uid=root;Pwd=root;";
    public MainAppWindow()
    {
        InitializeComponent();
    }
    
      // 2. Метод для кнопки входа
      private void BtnLogin_Click(object sender, RoutedEventArgs e)
      {
          // 1. Получаем текст из полей
          var loginInput = this.FindControl<TextBox>("TxtLogin")?.Text?.Trim();
          var passwordInput = this.FindControl<TextBox>("TxtPassword")?.Text?.Trim();
          
          try
          {
              using (var conn = new MySqlConnection(connectionString))
              {
                  conn.Open();

                  // Используем BINARY для точного сравнения регистра (Admin != admin)
                  // И TRIM на случай лишних пробелов в БД
                  string sql = "SELECT role_id FROM users WHERE BINARY login = @login AND password_hash = @pass LIMIT 1";

                  using (var cmd = new MySqlCommand(sql, conn))
                  {
                      // Привязываем переменные к параметрам
                      cmd.Parameters.AddWithValue("@login", loginInput);
                      cmd.Parameters.AddWithValue("@pass", passwordInput);

                      // Выполняем запрос
                      var result = cmd.ExecuteScalar();

                      if (result != null && result != DBNull.Value)
                      {
                          int roleId = Convert.ToInt32(result);
                          Console.WriteLine($"Вход разрешен! Role ID: {roleId}");
                          NavigateByRole(roleId);
                      }
                  }
              }
          }
          catch (Exception ex)
          {
              Console.WriteLine($"Критическая ошибка: {ex.Message}");
          }
      }


        private void NavigateByRole(int roleId)
        {
            Window nextWindow = null;

            // Сверяемся с вашей таблицей roles в DBeaver
            switch (roleId)
            {
                case 1: // Предположим, это Админ
                    nextWindow = new AdminWindow();
                    break;
                case 2: // Предположим, это Библиотекарь
                    nextWindow = new LibrarianWindow();
                    break;
                case 3: // Предположим, это Читатель
                    nextWindow = new ReaderWindow();
                    break;
            }

            if (nextWindow != null)
            {
                nextWindow.Show();
                this.Close(); // Закрываем окно логина
            }
        }
}
