using System.Data;
using System.Runtime.CompilerServices;
using CesiSpotifyWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CesiSpotifyWebApi.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsControllers : Controller
    {
        private IConfiguration _configuration;
        public ArtistsControllers(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IEnumerable<SpotifyArtist>> GetAsync()
        {
            List<SpotifyArtist> artists = new List<SpotifyArtist>();
            await using var conn = new NpgsqlConnection(_configuration.GetConnectionString("CesifyDB"));
            await conn.OpenAsync();

            await using (var cmd = new NpgsqlCommand("SELECT * FROM artists", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    artists.Add(new SpotifyArtist
                    {
                        Id = reader.GetInt32(0),
                        ArtistId = reader.GetString(1),
                        Name = reader.GetString(2),
                        Url = reader.GetString(3),
                        IconUrl = reader.GetString(4),
                        Popularity = reader.GetInt32(5),
                        FollowersCount = reader.GetInt32(6),
                        Genres = reader.GetString(7).Split('|'),
                    });
                }
            }
            await conn.CloseAsync();
            return artists;
        }

        [HttpGet("{id}")]
        public async Task<SpotifyArtist> Get(int id)
        {
            SpotifyArtist? artist = null;
            await using var conn = new NpgsqlConnection(_configuration.GetConnectionString("CesifyDB"));
            await conn.OpenAsync();

            await using (var cmd = new NpgsqlCommand("SELECT * FROM artists WHERE ID = $1", conn))
            {
                cmd.Parameters.AddWithValue(id);
                var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    artist = new SpotifyArtist
                    {
                        Id = reader.GetInt32(0),
                        ArtistId = reader.GetString(1),
                        Name = reader.GetString(2),
                        Url = reader.GetString(3),
                        IconUrl = reader.GetString(4),
                        Popularity = reader.GetInt32(5),
                        FollowersCount = reader.GetInt32(6),
                        Genres = reader.GetString(7).Split('|'),
                    };
                }
            }

            await conn.CloseAsync();
            return artist;
        }

        [HttpPost]
        public async Task Post([FromBody] SpotifyArtist spotifyArtist)
        {
            await using var conn = new NpgsqlConnection(_configuration.GetConnectionString("SpoopyDB"));
            await conn.OpenAsync();

            await using (var cmd = new NpgsqlCommand("INSERT INTO roles (artistid, name, url, iconurl, popularity, followscount, genres) VALUES ($1, $2, $3, $4, $5, $6, $7)", conn))
            {
                cmd.Parameters.AddWithValue(spotifyArtist.ArtistId);
                cmd.Parameters.AddWithValue(spotifyArtist.Name);
                cmd.Parameters.AddWithValue(spotifyArtist.Url);
                cmd.Parameters.AddWithValue(spotifyArtist.IconUrl);
                cmd.Parameters.AddWithValue(spotifyArtist.Popularity);
                cmd.Parameters.AddWithValue(spotifyArtist.FollowersCount);
                cmd.Parameters.AddWithValue(string.Join('|', spotifyArtist.Genres));
                await cmd.ExecuteNonQueryAsync();
            }

            await conn.CloseAsync();
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] SpotifyArtist spotifyArtist)
        {
            await using var conn = new NpgsqlConnection(_configuration.GetConnectionString("SpoopyDB"));
            await conn.OpenAsync();

            await using (var cmd = new NpgsqlCommand("UPDATE artists SET artistid = $1, name = $2, url = $3, iconurl = $4, popularity = $5, followscount = $6, genres = $7 WHERE ID = $8", conn))
            {
                cmd.Parameters.AddWithValue(spotifyArtist.ArtistId);
                cmd.Parameters.AddWithValue(spotifyArtist.Name);
                cmd.Parameters.AddWithValue(spotifyArtist.Url);
                cmd.Parameters.AddWithValue(spotifyArtist.IconUrl);
                cmd.Parameters.AddWithValue(spotifyArtist.Popularity);
                cmd.Parameters.AddWithValue(spotifyArtist.FollowersCount);
                cmd.Parameters.AddWithValue(string.Join('|', spotifyArtist.Genres));
                cmd.Parameters.AddWithValue(id);
                await cmd.ExecuteNonQueryAsync();
            }

            await conn.CloseAsync();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
