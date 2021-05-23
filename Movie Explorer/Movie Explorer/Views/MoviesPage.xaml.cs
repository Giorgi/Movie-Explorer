using MovieExplorer.ViewModels;
using Xamarin.Forms;

namespace MovieExplorer.Views
{
    public partial class MoviesPage : ContentPage
    {
        MoviesViewModel _viewModel;

        public MoviesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new MoviesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}