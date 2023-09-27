using G_Pigmy.ViewModels;
using System.Diagnostics;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace G_Pigmy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionPage : ContentPage
    {

        private bool show;

        private readonly CustomerViewModel _viewModel;
        public CollectionPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CustomerViewModel();
            CustomersList.ItemsSource = "";
            show = false;
        }


        private async void Make_Reciept(object sender, EventArgs e)
        {



            string action = await DisplayActionSheet("Are you sure you want to make this payment ?", "Cancel", "Yes", null, null, null);
            Debug.WriteLine("Action: " + action);

            //var popup = new Popup
            //{
            //    Size = new Size(350, 230),
            //    Content = new StackLayout
            //    {
            //        //HeightRequest = 100,
            //        Padding = new Thickness(0, 0, 0, 0),
            //        Children =
            //        {

            //             new Image
            //             {
            //                 Source = "icon_about.png"
            //             },

            //             new Label
            //             {
            //                  FontFamily="glab",
            //                  FontSize = 25,
            //                  VerticalOptions = LayoutOptions.Center,
            //                  HorizontalOptions = LayoutOptions.Center,
            //                  Text = "Are you sure to make payment",
            //                  TextColor = Color.Black,
            //                  Margin = new Thickness(0,0,0,0),

            //             },

            //             new Xamarin.Forms.Button
            //             {
            //                 Text = "Cancel",
            //                 WidthRequest = 120,
            //                 Margin = new Thickness(10,100,10,10),
            //                 HorizontalOptions = LayoutOptions.Start,

            //             },

            //             new Xamarin.Forms.Button
            //             {
            //                 Text = "Reciept",
            //                 WidthRequest = 120,
            //                 Margin = new Thickness(0,-65,10,0),
            //                 HorizontalOptions = LayoutOptions.End,

            //             }
            //        }
            //    }
            //};

            //App.Current.MainPage.Navigation.ShowPopup(popup);
            //DisplayAlert("Reciept", "Want to make reciept", "Yes");
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == "")
            {
                CustomersList.ItemsSource = "";
            }
            else
            {
                show = true;
                CustomersList.ItemsSource = _viewModel.GetSearchedCustomers(e.NewTextValue);
            }           
        }
    }
}