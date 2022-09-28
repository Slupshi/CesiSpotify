using System.Windows;
using CesiSpotify.UserControls;

namespace CesiSpotify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NavArtistsButtonClicked(object sender, RoutedEventArgs e)
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(new ArtistsUC());
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
