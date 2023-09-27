using Android.Views;
using G_Pigmy.Models;
using G_Pigmy.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace G_Pigmy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MiniReportPage : ContentPage
    {

       
       

        public ICommand FilterClick { get; set; }


        public MiniReportViewModel viewModel;
        public MiniReportPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MiniReportViewModel();

            Statements.ItemsSource = "";
           

        }






       
        

        private void filter(object sender, EventArgs e)
        {

        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            Recalculate();
        }

        void OnSwitchToggled(object sender, ToggledEventArgs args)
        {
            Recalculate();
        }

        void Recalculate()
        {
            //TimeSpan timeSpan = endDatePicker.Date - startDatePicker.Date +
            //    (includeSwitch.IsToggled ? TimeSpan.FromDays(1) : TimeSpan.Zero);

            //resultLabel.Text = String.Format("{0} day{1} between dates",
            //                                    timeSpan.Days, timeSpan.Days == 1 ? "" : "s");
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
           

        }
    }


   
}