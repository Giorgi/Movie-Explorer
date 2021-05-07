using Movie_Explorer.Models;
using Movie_Explorer.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TMDbLib.Objects.Search;
using Xamarin.Forms;

namespace Movie_Explorer.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private SearchMovie _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public ObservableCollection<SearchMovie> PopularMovies { get; }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<SearchMovie> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Movies";
            PopularMovies = new ObservableCollection<SearchMovie>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<SearchMovie>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
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

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(SearchMovie item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}