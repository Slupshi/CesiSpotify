using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesiSpotify.Models
{
    public class SpotifyArtist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int FollowersCount { get; set; }
        public int Popularity { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set; }
        public IEnumerable<string> Genres { get; set; }

        public SpotifyArtist()
        {

        }

        public SpotifyArtist(string id, string name, int followersCount, int popularity, string url, string iconUrl, IEnumerable<string> genres)
        {
            Id = id;
            Name = name;
            FollowersCount = followersCount;
            Popularity = popularity;
            Url = url;
            IconUrl = iconUrl;
            Genres = genres;
        }
    }
}
