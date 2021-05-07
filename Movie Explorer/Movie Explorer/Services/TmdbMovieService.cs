using System.Collections.Generic;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.Trending;

namespace Movie_Explorer.Services
{
    class TmdbMovieService : IMoviesService
    {
        TMDbClient client = new TMDbClient("3e9207282bc84acba8fbd995d46ff57b");

        public async Task<List<SearchMovie>> GetPopularMovies()
        {
            var trendingMoviesAsync = await client.GetTrendingMoviesAsync(TimeWindow.Week);

            return trendingMoviesAsync.Results;
        }
    }
}