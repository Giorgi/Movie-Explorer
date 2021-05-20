using System.Collections.Generic;
using System.Threading.Tasks;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace Movie_Explorer.Services
{
    public interface IMoviesService
    {
        Task<List<SearchMovie>> GetPopularMovies();
        Task<List<SearchMovie>> DiscoverMovies(string searchText);
        Task<Movie> GetMovie(int movieId);
    }
}