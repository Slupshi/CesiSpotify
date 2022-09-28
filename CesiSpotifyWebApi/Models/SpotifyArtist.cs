namespace CesiSpotifyWebApi.Models
{
    public class SpotifyArtist
    {
        public int Id { get; set; }
        public string ArtistId { get; set; }
        public string Name { get; set; }
        public int FollowersCount { get; set; }
        public int Popularity { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set; }
        public IEnumerable<string> Genres { get; set; }

        public SpotifyArtist()
        {

        }

        public SpotifyArtist(string artistId, string name, int followersCount, int popularity, string url, string iconUrl, IEnumerable<string> genres)
        {
            ArtistId = artistId;
            Name = name;
            FollowersCount = followersCount;
            Popularity = popularity;
            Url = url;
            IconUrl = iconUrl;
            Genres = genres;
        }
    }
}
