using System.Windows;
using CesiSpotify.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CesiSpotify
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        private ServiceCollection _services;
        private ApiService _apiService;

        public App()
        {
            _services = new ServiceCollection();
            _services.AddSingleton<ApiService>();
            _serviceProvider = _services.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _apiService = _serviceProvider.GetService<ApiService>();
            new MainWindow().Show();
        }
    }
}
