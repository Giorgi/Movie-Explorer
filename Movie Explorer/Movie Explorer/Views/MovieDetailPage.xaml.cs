using MovieExplorer.ViewModels;
using Xamarin.Forms;

namespace MovieExplorer.Views
{
    public partial class MovieDetailPage : ContentPage
    {
        public MovieDetailPage()
        {
            InitializeComponent();
            BindingContext = new MovieDetailViewModel();
        }
    }
}