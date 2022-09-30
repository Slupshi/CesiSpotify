using System.Windows;
using System.Windows.Controls;
using CesiSpotify.ViewModels;

namespace CesiSpotify.UserControls
{
    /// <summary>
    /// Interaction logic for ArtistsUC.xaml
    /// </summary>
    public partial class ArtistsUC : UserControl
    {
        private ArtistsViewModel _viewModel;
        public ArtistsUC(ArtistsViewModel artistsViewModel)
        {
            DataContext = _viewModel = artistsViewModel; ;
            InitializeComponent();


        }

        private void SearchButtonClicked(object sender, RoutedEventArgs e)
        {
            _viewModel.Search(SearchBar.Text);
        }
    }
}
