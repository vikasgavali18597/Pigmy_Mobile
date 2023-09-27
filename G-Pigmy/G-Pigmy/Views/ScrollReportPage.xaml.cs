

using G_Pigmy.Models;
using G_Pigmy.ViewModels;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace G_Pigmy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScrollReportPage : ContentPage
    {

        public ScrollReportViewModel viewModel;
        private ObservableCollection<ScrollReport> report;

        PdfDocument document;
        public ScrollReportPage()
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