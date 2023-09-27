using G_Pigmy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace G_Pigmy.ViewModels
{
    public class CollectionViewModel : BaseViewModel
    {
        public ObservableCollection<Customer> Customers { get; }

        public ICommand ButtonClickedCommand { get; set; }


        public CollectionViewModel()
        {
            Customers = new ObservableCollection<Customer>
            {
                new Customer { Id = new Guid(), Name = "Andrew Balbirnie", AccountNumber = "12341", AvailableBalance = 100, CurrentBalance = 200, AccountOpenDate = DateTime.Now, Status = false},
                new Customer { Id = new Guid(), Name = "Paul Stirling", AccountNumber = "12342", AvailableBalance = 2000, CurrentBalance = 2100, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Lorcan Tucker ", AccountNumber = "12343", AvailableBalance = 4500, CurrentBalance = 4700, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Harry Tector", AccountNumber = "12344", AvailableBalance = 50000, CurrentBalance = 50100, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Kavi O Brain", AccountNumber = "12345", AvailableBalance = 800, CurrentBalance =1000, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "George Dockrell", AccountNumber = "12346", AvailableBalance = 1200, CurrentBalance = 2000, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Mark Adair", AccountNumber = "12347", AvailableBalance = 300, CurrentBalance = 5000, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Barry McCarthy", AccountNumber = "12348", AvailableBalance = 7800, CurrentBalance = 7900, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Craig Young", AccountNumber = "12349", AvailableBalance = 4000, CurrentBalance = 4200, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Joshua Little", AccountNumber = "12350", AvailableBalance = 40000, CurrentBalance = 41000, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Benjamin White", AccountNumber = "12351", AvailableBalance = 7800, CurrentBalance = 7900, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Fionn Hand", AccountNumber = "12352", AvailableBalance = 500, CurrentBalance = 700, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = " Theo van Woerkom", AccountNumber = "12353", AvailableBalance = 700, CurrentBalance = 900, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = " Gareth Delany", AccountNumber = "12354", AvailableBalance = 1080, CurrentBalance = 2100, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = " Ross Adair", AccountNumber = "12355", AvailableBalance = 2300, CurrentBalance = 2400, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Heinrich Malan", AccountNumber = "12356", AvailableBalance = 3000, CurrentBalance = 3500, AccountOpenDate = DateTime.Now , Status = false},
                new Customer { Id = new Guid(), Name = " Ryan Eagleson", AccountNumber = "12357", AvailableBalance = 900, CurrentBalance = 1200, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Gary Wilson", AccountNumber = "12358", AvailableBalance = 1000, CurrentBalance = 1100, AccountOpenDate = DateTime.Now, Status = false },
               new Customer { Id = new Guid(), Name = " Nathan Hauritz", AccountNumber = "12359", AvailableBalance = 100, CurrentBalance = 200, AccountOpenDate = DateTime.Now , Status = false},
            };
            ButtonClickedCommand = new Command<Customer>(OnButtonClicked);
        }

        public IEnumerable<Customer> GetSearchedCustomers(string searchText = null)
        {
            return Customers.Where(p => p.Name.ToLower().StartsWith(searchText.ToLower()) 
            || p.AccountNumber.ToLower().Contains(searchText.ToLower()));
        }

        private async void OnButtonClicked(Customer obj)
        {

            var result = await Application.Current.MainPage.DisplayActionSheet("Are you sour make this payment ..?", "Cancel", "Ok");

            if (result == "Ok")
            {
                var oldCustomer = Customers.Where(x => x.Name == obj.Name).FirstOrDefault();

                var newCustomer = new Customer
                {
                    Id = new Guid(),
                    AccountNumber = obj.AccountNumber,
                    Name = oldCustomer.Name,
                    AvailableBalance = oldCustomer.AvailableBalance,
                    CurrentBalance = oldCustomer.CurrentBalance + obj.Amount,
                    Status = true,
                };

                Customers.Remove(oldCustomer);
                Customers.Add(newCustomer);
            }
        }
    }
}
