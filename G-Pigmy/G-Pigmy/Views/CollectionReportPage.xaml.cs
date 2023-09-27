using G_Pigmy.Models;
using G_Pigmy.ViewModels;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.Drawing;

namespace G_Pigmy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionReportPage : ContentPage
    {
        public ScrollReportViewModel viewModel;
        private ObservableCollection<ScrollReport> report;

        PdfDocument document;
        public CollectionReportPage()
        {
            InitializeComponent();
            report = new ObservableCollection<ScrollReport>();
            document = new PdfDocument();
            BindingContext = viewModel = new ScrollReportViewModel();
            report = viewModel.ScrollReports;
        }



        private void OnPDF(object sender, EventArgs e)
        {
            foreach (var item in report)
            {
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                graphics.DrawString($"A/C No {item.AccountNumber}  " +
                    $"Name {item.Name}  " +
                    $"Deposite {item.Deposite}  " +
                    $"Balance {item.Balance} " +
                    $"Date {item.TransactionDate}",
                    new PdfStandardFont(PdfFontFamily.Helvetica, 12), PdfBrushes.Black, new PointF(10, 10));
            }

            //Stream pdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(@"C:\Users\glabl\OneDrive\Documents\TestFiels" + "PDF_Scroll.pdf");
            //document.Save(pdfDocumentStream);
        }

    }
}