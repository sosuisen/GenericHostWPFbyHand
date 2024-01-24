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

        private async void StartupHandler(object sender, StartupEventArgs e)
        {
            await _Host.StartAsync();
            _Host.Services.GetRequiredService<MainWindow>().Show();
        }

        private async void ExitHandler(object sender, ExitEventArgs e)
        {
            await _Host.StopAsync();
            _Host.Dispose();
        }
    }
}
