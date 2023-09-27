using G_Pigmy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace G_Pigmy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomeViewModel homeView;



        public string Name = "Daniel B. Whitener";
        public string AgentCode = "01168";
        public decimal Collection = 55000;
        public string Mobile = "1234567890";
        public decimal Commission = 1100;
        public long TotalCustome = 100;
        public long VisitedCustomer = 40;





















        public HomePage()
        {
            InitializeComponent();
            SizeChanged += HOmePageSizeChanged;
            BindingContext = homeView = new HomeViewModel();
        }


        void HOmePageSizeChanged(object sender, EventArgs e)
        {
            //home.WidthRequest = Math.Min(this.Width, 400);
        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var popup = new Popup
            {
                Size = new Size(350, 230),
                HorizontalOptions = LayoutOptions.Center, 
                VerticalOptions = LayoutOptions.Center,
                Content = new StackLayout
                {
                    //HeightRequest = 100,
                    Padding = new Thickness(0, 0, 0, 0),
                    Margin = new Thickness(10, 50),
                    BackgroundColor = new Color(150,150,232,0.14),
                    Children =
                    {

                         new Image
                         {
                             Source = "icon_about.png"
                         },

                         new Label
                         {
                              FontFamily="glab",
                              FontSize = 25,
                              VerticalOptions = LayoutOptions.Center,
                              HorizontalOptions = LayoutOptions.Center,
                              Text = "Agent Information",
                              TextColor = Color.Black,
                              Margin = new Thickness(0,0,0,0),

                         },

                         new Label
                         {
                              FontFamily="glab",
                              FontSize = 25,
                              VerticalOptions = LayoutOptions.Center,
                              HorizontalOptions = LayoutOptions.Center,
                              Text = "Vikas Gavali",
                              TextColor = Color.Black,
                              Margin = new Thickness(0,10,0,0),

                         },

                         new Label
                         {
                              FontFamily="glab",
                              FontSize = 25,
                              VerticalOptions = LayoutOptions.Center,
                              HorizontalOptions = LayoutOptions.Center,
                              Text = "123456",
                              TextColor = Color.Black,
                              Margin = new Thickness(0,15,0,0),

                         },
                         

                         //new Xamarin.Forms.Button
                         //{
                         //    Text = "Cancel",
                         //    WidthRequest = 120,
                         //    Margin = new Thickness(10,100,10,10),
                         //    HorizontalOptions = LayoutOptions.Start,

                         //},

                         //new Xamarin.Forms.Button
                         //{
                         //    Text = "Reciept",
                         //    WidthRequest = 120,
                         //    Margin = new Thickness(0,-65,10,0),
                         //    HorizontalOptions = LayoutOptions.End,

                         //}
                    }
                }
            };
            App.Current.MainPage.Navigation.ShowPopup(popup);
        }

        private void FinalSubmit(object sender, EventArgs e)
        {
            DisplayAlert("Final Submit", "Submiting the final transaction details ..!", "Ok", "Cancel");
        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {

        }
    }
}