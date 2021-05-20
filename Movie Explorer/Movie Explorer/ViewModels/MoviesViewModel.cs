using Movie_Explorer.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TMDbLib.Objects.Search;
using Xamarin.Forms;

namespace Movie_Explorer.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        private SearchMovie _selectedItem;

        public ObservableCollection<SearchMovie> PopularMovies { get; }
        public ObservableCollection<SearchMovie> DiscoverMovies { get; }

        public Command LoadItemsCommand { get; }
        public Command SearchMoviesCommand { get; }
        
        public Command<SearchMovie> ItemTapped { get; }

        public MoviesViewModel()
        {
            Title = "Movies";
            PopularMovies = new ObservableCollection<SearchMovie>();
            DiscoverMovies = new ObservableCollection<SearchMovie>();
            
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            SearchMoviesCommand = new Command<string>(async text => await ExecuteSearchMoviesCommand(text));

            ItemTapped = new Command<SearchMovie>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                PopularMovies.Clear();
                var popularMovies = await MoviesService.GetPopularMovies();
                
                foreach (var movie in popularMovies)
                {
                    PopularMovies.Add(movie);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteSearchMoviesCommand(string text)
        {
            IsBusy = true;

            try
            {
                DiscoverMovies.Clear();
                
                if (!string.IsNullOrEmpty(text))
                {
                    var searchResult = await MoviesService.DiscoverMovies(text);

                    foreach (var movie in searchResult)
                    {
                        DiscoverMovies.Add(movie);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public SearchMovie SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        
        async void OnItemSelected(SearchMovie item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(MovieDetailPage)}?{nameof(MovieDetailViewModel.MovieId)}={item.Id}");
        }
    }
}