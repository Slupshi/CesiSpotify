using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using CesiSpotify.Graph;
using CesiSpotify.Models;
using CesiSpotify.Services;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace CesiSpotify.ViewModels
{
    public class ArtistsViewModel : ViewModelBase
    {
        private SpotifyService _spotifyService;
        public ArtistsViewModel(SpotifyService spotifyService)
        {
            _spotifyService = spotifyService;

            PopularitySeries = new ObservableCollection<ISeries>();
            PopularityXAxes = new List<Axis>();

            FollowsSeries = new ObservableCollection<ISeries>();
            FollowsXAxes = new List<Axis>();
        }

        public async Task Search(string searchWord)
        {
            SearchWord = searchWord;
            List<SpotifyArtist> artists = (await _spotifyService.GetArtistBySearch(searchWord, "FR")).ToList();

            PopularitySeries.Clear();
            PopularitySeries.Add(new PopularitySeries(artists));
            PopularityXAxes.Clear();
            PopularityXAxes.Add(new CesifyGraphXAxis(artists, "Artists Popularity"));

            FollowsSeries.Clear();
            FollowsSeries.Add(new FollowsSeries(artists));
            FollowsXAxes.Clear();
            FollowsXAxes.Add(new CesifyGraphXAxis(artists, "Artists Followers Count"));
        }

        private string _searchWord = "";
        public string SearchWord
        {
            get => _searchWord;
            set
            {
                if(_searchWord != value)
                {
                    _searchWord = value;
                    OnPropertyChanged();
                }                
            }
        }

        public ObservableCollection<ISeries> PopularitySeries { get; set; }
        public List<Axis> PopularityXAxes { get; set; }
        public Axis[] PopularityYAxes { get; set; } =
        {
            new Axis
            {
                LabelsPaint = new SolidColorPaint(SKColors.White),
                MaxLimit = 100,
                MinLimit = 0,

            }
        };

        public ObservableCollection<ISeries> FollowsSeries { get; set; }
        public List<Axis> FollowsXAxes { get; set; }
        public Axis[] FollowsYAxes { get; set; } =
        {
            new Axis
            {
                LabelsPaint = new SolidColorPaint(SKColors.White),
                MinLimit = 0,  
            }
        };

    }
}
