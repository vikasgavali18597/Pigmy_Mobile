using G_Pigmy.Models;
using System;
using System.Collections.ObjectModel;

namespace G_Pigmy.ViewModels
{
    public class ScrollReportViewModel
    {

        public ObservableCollection<ScrollReport> ScrollReports { get; set; }
        public ScrollReportViewModel()
        {
            ScrollReports = new ObservableCollection<ScrollReport>
            {
                new ScrollReport { Id = new Guid(), Name = "Andrew Balbirnie", AccountNumber = "12341", Deposite = 100, Balance = 200, TransactionDate = DateTime.Now},
                new ScrollReport { Id = new Guid(), Name = "Paul Stirling", AccountNumber = "12342", Deposite = 2000, Balance = 2100, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = "Lorcan Tucker ", AccountNumber = "12343", Deposite = 4500, Balance = 4700, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = "Harry Tector", AccountNumber = "12344", Deposite = 50000, Balance = 50100, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = "Kavi O Brain", AccountNumber = "12345", Deposite = 800, Balance =1000, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = "George Dockrell", AccountNumber = "12346", Deposite = 1200, Balance = 2000, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = "Mark Adair", AccountNumber = "12347", Deposite = 300, Balance = 5000, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = "Barry McCarthy", AccountNumber = "12348", Deposite = 7800, Balance = 7900, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = "Craig Young", AccountNumber = "12349", Deposite = 4000, Balance = 4200, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = "Joshua Little", AccountNumber = "12350", Deposite = 40000, Balance = 41000, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = "Benjamin White", AccountNumber = "12351", Deposite = 7800, Balance = 7900, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = "Fionn Hand", AccountNumber = "12352", Deposite = 500, Balance = 700, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = " Theo van Woerkom", AccountNumber = "12353", Deposite = 700, Balance = 900, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = " Gareth Delany", AccountNumber = "12354", Deposite = 1080, Balance = 2100, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = " Ross Adair", AccountNumber = "12355", Deposite = 2300, Balance = 2400, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = "Heinrich Malan", AccountNumber = "12356", Deposite = 3000, Balance = 3500, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = " Ryan Eagleson", AccountNumber = "12357", Deposite = 900, Balance = 1200, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = "Gary Wilson", AccountNumber = "12358", Deposite = 1000, Balance = 1100, TransactionDate = DateTime.Now },
                new ScrollReport { Id = new Guid(), Name = " Nathan Hauritz", AccountNumber = "12359", Deposite = 100, Balance = 200, TransactionDate = DateTime.Now },
            };
        }
    }
}