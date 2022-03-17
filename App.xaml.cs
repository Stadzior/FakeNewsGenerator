using System.Windows;
using FakeNewsGenerator.Service;
using FakeNewsGenerator.Service.Interfaces;
using FakeNewsGenerator.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
        var accessKey = new ConfigurationBuilder()
            .AddJsonFile("apiConfig.json")
            .Build()
            .GetSection("Configuration")
            .GetValue<string>("AccessKey");

        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<IFakeNewsService, FakeNewsService>(_ => new FakeNewsService(accessKey));
                services.AddSingleton<FakeNewsViewModel>();
            }).Build();
    }

    protected override void OnStartup(StartupEventArgs args)
    {
        base.OnStartup(args);

        Host.Start();
        Host.Services.GetService<MainWindow>()?.Show();
    }
}