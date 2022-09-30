using System.Windows;
using CesiSpotify.Services;
using CesiSpotify.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.Kernel;

namespace CesiSpotify
{
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        private ServiceCollection _services;
        private ApiService _apiService;
        private LocalApiService _localApiService;
        private SpotifyService _spotifyService;
        private MainViewModel _mainViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _services = new ServiceCollection();
            _services.AddSingleton<ApiService>();
            _services.AddSingleton<LocalApiService>();
            _services.AddSingleton<SpotifyService>();
            _services.AddSingleton<MainViewModel>();
            _serviceProvider = _services.BuildServiceProvider();

            _apiService = _serviceProvider.GetService<ApiService>();
            _localApiService = _serviceProvider.GetService<LocalApiService>();
            _spotifyService = _serviceProvider.GetService<SpotifyService>();
            _mainViewModel = _serviceProvider.GetService<MainViewModel>();

            new MainWindow(_mainViewModel, _spotifyService).Show();
        }
    }
}
