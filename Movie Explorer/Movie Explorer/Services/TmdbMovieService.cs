using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;
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

        public async Task<List<SearchMovie>> DiscoverMovies(string searchText)
        {
            var keywordAsync = await client.SearchKeywordAsync(searchText);

            if (keywordAsync.Results.Any())
            {
                var movies = await client.DiscoverMoviesAsync()
                                         .IncludeWithAnyOfKeywords(keywordAsync.Results.Select(keyword => keyword.Id))
                                         .Query();

                return movies.Results;
            }

            return new List<SearchMovie>();
        }

        public Task<Movie> GetMovie(int movieId)
        {
            return client.GetMovieAsync(movieId, MovieMethods.Videos | MovieMethods.Credits);
        }
    }
}