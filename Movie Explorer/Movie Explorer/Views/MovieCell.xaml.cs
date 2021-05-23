using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieExplorer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieCell : Grid
    {
        public MovieCell()
        {
            InitializeComponent();
        }
    }
}