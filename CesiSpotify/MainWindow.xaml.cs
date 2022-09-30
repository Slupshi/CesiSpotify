using System.Windows;
using CesiSpotify.Services;
using CesiSpotify.UserControls;
using CesiSpotify.ViewModels;

namespace CesiSpotify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SpotifyService _spotifyService;
        private MainViewModel _mainviewModel;
        public MainWindow(MainViewModel mainViewModel, SpotifyService spotifyService)
        {
            DataContext = _mainviewModel = mainViewModel;
            _spotifyService = spotifyService;
            InitializeComponent();
            ContentGrid.Children.Add(new ArtistsUC(new ArtistsViewModel(_spotifyService)));
        }

        public string PageTitle { get => _mainviewModel.Title; }

        private void NavArtistsButtonClicked(object sender, RoutedEventArgs e)
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new ArtistsUC(new ArtistsViewModel(_spotifyService)));
        }

        private void NavAlbumsButtonClicked(object sender, RoutedEventArgs e)
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new AlbumUC());
        }

        private void NavTracksButtonClicked(object sender, RoutedEventArgs e)
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new TracksUC());
        }
    }
}
