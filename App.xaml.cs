using System.Windows;
using FakeNewsGenerator.Data;
using FakeNewsGenerator.Service;
using FakeNewsGenerator.Service.Interfaces;
using FakeNewsGenerator.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace FakeNewsGenerator;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public IHost Host { get; set; }

    public FakeNewsViewModel? FakeNewsViewModel
        => Host?.Services.GetService<FakeNewsViewModel>();

    public App()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("apiConfig.json")
            .Build();

        var accessKey = configuration
            .GetSection("Configuration")
            .GetValue<string>("AccessKey");

        var connectionString = configuration
            .GetConnectionString("FakeNewsContext");

        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .UseSerilog()
            .ConfigureServices(services =>
            {
                services.AddDbContextFactory<FakeNewsContext>(options => options.UseSqlServer(connectionString));
                services.AddSingleton<MainWindow>();
                services.AddSingleton<IFakeNewsService, FakeNewsService>(provider => new FakeNewsService(accessKey, provider.GetService<IDbContextFactory<FakeNewsContext>>()!));
                services.AddSingleton<FakeNewsViewModel>();
            }).Build();

        var logConfiguration = new ConfigurationBuilder()
            .AddJsonFile("logConfig.json")
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom
            .Configuration(logConfiguration)
            .CreateLogger();
    }

    protected override void OnStartup(StartupEventArgs args)
    {
        base.OnStartup(args);

        Host.Start();
        Host.Services.GetService<MainWindow>()?.Show();
    }
}