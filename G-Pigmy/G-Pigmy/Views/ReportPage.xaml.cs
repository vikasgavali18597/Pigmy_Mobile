using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace G_Pigmy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportPage : ContentPage
    {
        public ICommand LabelTappedCommand { get; private set; }

        public ReportPage()
        {
            InitializeComponent();
            LabelTappedCommand = new Command(OnLabelTapped);
        }


        void OnLabelTapped()
        {
            DisplayAlert("Image", "ok", "tapped");
            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MiniReportPage());
        }


        private void ScrollReport_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScrollReportPage());
        }


        private void BalanceReport_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BalanceReportPage());
        }

        private void CollectionReport_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CollectionReportPage());
        }
    }
}