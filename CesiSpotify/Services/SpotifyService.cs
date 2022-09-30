using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CesiSpotify.Models;
using SpotifyAPI.Web;

namespace CesiSpotify.Services
{
    public class SpotifyService
    {
        private SpotifyClient _spotifyClient;
        private LocalApiService _localApiService;
        public SpotifyService(LocalApiService localApiService) 
        {
            string[] authFile = File.ReadAllLines(@"../../../spotifyAuth.txt");
            string? clientId = authFile.FirstOrDefault(x => x.Contains("CLIENT_ID"))?.Split('=').Last().Trim();
            string clientSecret = authFile.Where(x => x.Contains("CLIENT_SECRET")).First().Split('=').Last().Trim();

            _spotifyClient = new SpotifyClient(SpotifyClientConfig.CreateDefault().WithAuthenticator(new ClientCredentialsAuthenticator(clientId!, clientSecret)));
            _localApiService = localApiService;
        }

        public async Task<List<string>> GetMarketsList()
        {
            return (await _spotifyClient.Markets.AvailableMarkets()).Markets;
        }

        public async Task<IEnumerable<SpotifyArtist>> GetArtistBySearch(string search, string market)
        {
            List<SpotifyArtist> artistsList = new List<SpotifyArtist>();
            var response = await _spotifyClient.Search.Item(new SearchRequest(type: SearchRequest.Types.Artist, query: search)
            {
                Limit = 10,
                Market = market,
            });
            List<FullArtist> artists = response.Artists.Items;
            artists.ForEach(artist => artistsList.Add(new SpotifyArtist()
            {
                ArtistId = artist.Id,
                Popularity = artist.Popularity,
                Name = artist.Name,
                Url = artist.Href,
                IconUrl = artist.Images.First().Url,
                Genres = artist.Genres,
                FollowersCount = artist.Followers.Total,
            })
            );
            var artistsDB = await _localApiService.GetSpotifyArtistsAsync();
            if(artistsDB != null)
            {
                foreach(var artist in artistsList)
                {
                    if(artistsDB.Contains(artist) && artistsDB.FirstOrDefault(x => x == artist) == null)
                    {                        
                        await _localApiService.PutSpotifyArtistAsync(artist);
                    }
                    else
                    {
                        await _localApiService.PostSpotifyArtistAsync(artist);
                    }
                }
            }
            return artistsList;
        }
    }
}
