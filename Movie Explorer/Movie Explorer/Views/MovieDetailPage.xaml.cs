using Movie_Explorer.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Movie_Explorer.Views
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