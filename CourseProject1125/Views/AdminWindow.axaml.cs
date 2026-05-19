using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CourseProject1125.ViewModels;

namespace CourseProject1125.Views;

public partial class AdminWindow : Window
{
    public AdminWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel(); 
    }
}