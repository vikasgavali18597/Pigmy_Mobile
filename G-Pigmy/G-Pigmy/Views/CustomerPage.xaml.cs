using G_Pigmy.ViewModels;
using System.Diagnostics;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.ObjectModel;
using System.Collections.ObjectModel;
using G_Pigmy.Models;
using Android.Widget;
using System.Windows.Input;
using Java.Lang.Reflect;
using Android.Icu.Util;
using Android.Accounts;
using Xamarin.CommunityToolkit.UI.Views;

namespace G_Pigmy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerPage : ContentPage
    {
        readonly CustomerViewModel _customerViewModel;
        private Expander myExpander;

        public CustomerPage()
        {
            InitializeComponent();
            //BindingContext =
            BindingContext = _customerViewModel = new CustomerViewModel();
            CustomersList.ItemsSource = _customerViewModel.Customers;
            myExpander = new Expander();
            // 
            // Customers.ItemsSource = _customerViewModel.Customers;



            //MessagingCenter.Subscribe<CustomerViewModel>(this, "ShowConfirmation", async (sender) =>
            //{
            //    bool result = await DisplayAlert("Confirmation", "Are you sure?", "Yes", "No");

            //    if (result)
            //    {
            //        // User clicked 'Yes'
            //    }
            //    else
            //    {
            //        // User clicked 'No'
            //    }
            //});
        }

        private void CloseExpanderButton_Clicked(object snder, EventArgs e)
        {
            myExpander.IsExpanded = false;
        }
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _customerViewModel.OnAppearing();
        }


        private async void Make_Reciept(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Are you sour to make this payment.?", "Cancel", "Yes", null, null, null);
            Debug.WriteLine("Action: " + action);

          
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            CustomersList.ItemsSource = _customerViewModel.GetSearchedCustomers(e.NewTextValue);
        }

    }
}