using Movie_Explorer.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Movie_Explorer.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new MovieDetailViewModel();
        }
    }
}