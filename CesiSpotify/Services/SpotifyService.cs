using System.Threading.Tasks;
using CesiSpotify.Enums;
using CesiSpotify.Models;

namespace CesiSpotify.Services
{
    public class SpotifyService
    {
        private ApiService _apiService;
        public SpotifyService(ApiService apiService) 
        {
            _apiService = apiService;
        }

        public async Task<SpotifyArtist> GetArtistBySearch(string search)
        {
            return await _apiService.HttpGetAsync<SpotifyArtist>($"https://api.spotify.com/v1/search?query={search}&type=artist&market=FR&offset=0&limit=20");
        }

    }
}
