using System.Collections.Generic;
using System.Threading.Tasks;
using TMDbLib.Objects.Search;

namespace Movie_Explorer.Services
{
    public interface IMoviesService
    {
        Task<List<SearchMovie>> GetPopularMovies();
        Task<List<SearchMovie>> DiscoverMovies(string searchText);
    }
}