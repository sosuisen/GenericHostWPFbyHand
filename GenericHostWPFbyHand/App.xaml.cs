using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace GenericHostWPFbyHand
{
    public partial class App : Application
    {
        private readonly IHost _Host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainWindow>();
            })
            .Build();

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _Host.StartAsync();
            _Host.Services.GetRequiredService<MainWindow>().Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _Host.StopAsync();
            _Host.Dispose();
            base.OnExit(e);
        }
    }
}
