using System.Collections.Generic;
using System.Threading.Tasks;
using CesiSpotify.Models;

namespace CesiSpotify.Services
{
    public class LocalApiService
    {
        private string _baseUrl;
        private int _ports;
        private ApiService _apiService;
        public LocalApiService(ApiService apiService) 
        { 
            _apiService = apiService;
            _ports = 7167;
            _baseUrl = $"https://localhost:{_ports}/api/";
        }

        public async Task<IEnumerable<SpotifyArtist>> GetSpotifyArtistsAsync()
        {
            return await _apiService.HttpGetAsync<IEnumerable<SpotifyArtist>>($"{_baseUrl}artists");
        }

        public async Task<SpotifyArtist> GetSpotifyArtistAsync(string id)
        {
            return await _apiService.HttpGetAsync<SpotifyArtist>($"{_baseUrl}artists/{id}");
        }

        public async Task<bool> PostSpotifyArtistAsync(SpotifyArtist model)
        {
            return await _apiService.HttpPostAsync($"{_baseUrl}artists", model);
        }

        public async Task<bool> PutSpotifyArtistAsync(SpotifyArtist model)
        {
            return await _apiService.HttpPutAsync($"{_baseUrl}artists/{model.Id}", model);
        }

    }
}
