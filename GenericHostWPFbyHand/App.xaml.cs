using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace GenericHostWPFbyHand
{
    public partial class App : Application
    {
        private readonly IHost _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainWindow>();
            })
            .Build();

        private async void StartupHandler(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
            _host.Services.GetRequiredService<MainWindow>().Show();
        }

        private async void ExitHandler(object sender, ExitEventArgs e)
        {
            // Use using to ensure that the host is disposed if exceptions are thrown in StopAsync
            using (_host)
            {
                await _host.StopAsync();
            }
        }
    }
}
