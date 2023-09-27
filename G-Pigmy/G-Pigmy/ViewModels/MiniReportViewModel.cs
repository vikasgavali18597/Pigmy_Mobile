using G_Pigmy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace G_Pigmy.ViewModels
{
    public class MiniReportViewModel : BaseViewModel
    {
        private FilterViewModel _filter;

        public bool show = false;
        public ObservableCollection<Statement> Statements { get; set;  }


        public ICommand ApplyFilterCommand { get; private set; }
        private ObservableCollection<Statement> allUsersStatements { get; set;}
        public ICommand ButtonClickedCommand { get; set; }



        public string AccountNumber { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }





        public MiniReportViewModel()
        {
          
            allUsersStatements = new ObservableCollection<Statement>
            {
                new Statement { Id = new Guid(), Name = "Andrew Balbirnie", AccountNumber = "123401", Balance = 100, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Andrew Balbirnie", AccountNumber = "12341", Balance = 200, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Andrew Balbirnie", AccountNumber = "12341", Balance = 300, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Andrew Balbirnie", AccountNumber = "12341", Balance = 400, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Andrew Balbirnie", AccountNumber = "12341", Balance = 500, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Andrew Balbirnie", AccountNumber = "12341", Balance = 500, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Andrew Balbirnie", AccountNumber = "12341", Balance = 600, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Andrew Balbirnie", AccountNumber = "12341", Balance = 700, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Andrew Balbirnie", AccountNumber = "12341", Balance = 800, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Andrew Balbirnie", AccountNumber = "12341", Balance = 900, Deposite = 100, TransactionDate = DateTime.Now },

                new Statement { Id = new Guid(), Name = "Paul Stirling", AccountNumber = "12342", Balance = 100, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Paul Stirling", AccountNumber = "12342", Balance = 200, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Paul Stirling", AccountNumber = "12342", Balance = 300, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Paul Stirling", AccountNumber = "12342", Balance = 400, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Paul Stirling", AccountNumber = "12342", Balance = 500, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Paul Stirling", AccountNumber = "12342", Balance = 600, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Paul Stirling", AccountNumber = "12342", Balance = 700, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Paul Stirling", AccountNumber = "12342", Balance = 800, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Paul Stirling", AccountNumber = "12342", Balance = 900, Deposite = 100, TransactionDate = DateTime.Now },
                new Statement { Id = new Guid(), Name = "Paul Stirling", AccountNumber = "12342", Balance = 1000, Deposite = 100, TransactionDate = DateTime.Now },
            };

           ApplyFilterCommand = new Command(ApplyFilter);  
        }









       
        //public FilterViewModel Filter
        //{
        //    get {  if (Filter == null)
        //                return new FilterViewModel();
        //            return _filter; }
        //    set
        //    {
        //        if (_filter != value)
        //        {
        //            _filter = value;
        //            OnPropertyChanged(nameof(Filter));
        //        }
        //    }
        //}



        private void  ApplyFilter()
        {
            //You can access the filter properties and perform the filtering logic here
            //string name = Filter.AccountNumber;
            //DateTime startDate = Filter.StartDate;
            //DateTime endDate = Filter.EndDate;

            // Perform filtering based on the provided criteria
            // ...
            var collection = allUsersStatements.Where(x => x.AccountNumber == AccountNumber.ToString());

            Statements = new ObservableCollection<Statement>(collection);
            // Update the UI with the filtered results
            // ...
        }


        private void OnButtonClicked(Statement obj)
        {
            Statements = (ObservableCollection<Statement>)allUsersStatements.Where(x => x.AccountNumber == obj.AccountNumber
            && x.TransactionDate >= obj.TransactionDate && x.TransactionDate <= obj.TransactionDate);
        }



        public IEnumerable<Statement> GetSearchedCustomers(string searchText = null)
        {
            return Statements.Where(p =>  p.AccountNumber.ToLower().Contains(searchText.ToLower()) );
        }       
    }
}
