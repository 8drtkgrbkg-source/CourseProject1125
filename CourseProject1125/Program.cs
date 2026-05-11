using Avalonia;
using System;
using CourseProject1125.DB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CourseProject1125;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder().ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables();
            }).
            ConfigureServices((c, s) =>
            {
                s.Configure<Connection>(c.Configuration.GetSection("DataBaseConnection"));
            }).Build();
        BuildAvaloniaApp(host.Services)
            .StartWithClassicDesktopLifetime(args);
        
    }


    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp(IServiceProvider hostServices)
        => AppBuilder.Configure(()=>new App(hostServices))
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}