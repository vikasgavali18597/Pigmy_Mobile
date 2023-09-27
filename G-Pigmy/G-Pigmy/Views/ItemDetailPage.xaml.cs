using G_Pigmy.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace G_Pigmy.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}