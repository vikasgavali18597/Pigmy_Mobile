using G_Pigmy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Pigmy.Services
{
    public class MockCustomerStore : IDataStore<Customer>
    {

        readonly List<Customer> customers;

        public MockCustomerStore()
        {
            customers = new List<Customer>()
            {
              new Customer { Id = new Guid(), Name = "Andrew Andrew Balbirnie", AccountNumber = "12341", AvailableBalance = 100, CurrentBalance = 200, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = "Paul Stirling ", AccountNumber = "12342", AvailableBalance = 2000, CurrentBalance = 2100, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = "Lorcan Tucker ", AccountNumber = "12343", AvailableBalance = 4500, CurrentBalance = 4700, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = "Harry Tector", AccountNumber = "12344", AvailableBalance = 50000, CurrentBalance = 50100, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = "Kavi O Brain", AccountNumber = "12345", AvailableBalance = 800, CurrentBalance =1000, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = "George Dockrell", AccountNumber = "12346", AvailableBalance = 1200, CurrentBalance = 2000, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = "Mark Adair", AccountNumber = "12347", AvailableBalance = 300, CurrentBalance = 5000, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = "Barry McCarthy", AccountNumber = "12348", AvailableBalance = 7800, CurrentBalance = 7900, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = "Craig Young", AccountNumber = "12349", AvailableBalance = 4000, CurrentBalance = 4200, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = "Joshua Little", AccountNumber = "12350", AvailableBalance = 40000, CurrentBalance = 41000, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = "Benjamin White", AccountNumber = "12351", AvailableBalance = 7800, CurrentBalance = 7900, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = "Fionn Hand", AccountNumber = "12352", AvailableBalance = 500, CurrentBalance = 700, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = " Theo van Woerkom", AccountNumber = "12353", AvailableBalance = 700, CurrentBalance = 900, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = " Gareth Delany", AccountNumber = "12354", AvailableBalance = 1080, CurrentBalance = 2100, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = " Ross Adair", AccountNumber = "12355", AvailableBalance = 2300, CurrentBalance = 2400, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = "Heinrich Malan", AccountNumber = "12356", AvailableBalance = 3000, CurrentBalance = 3500, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = " Ryan Eagleson", AccountNumber = "12357", AvailableBalance = 900, CurrentBalance = 1200, AccountOpenDate = DateTime.Now },
                new Customer { Id = new Guid(), Name = "Gary Wilson", AccountNumber = "12358", AvailableBalance = 1000, CurrentBalance = 1100, AccountOpenDate = DateTime.Now },
               new Customer { Id = new Guid(), Name = " Nathan Hauritz", AccountNumber = "12359", AvailableBalance = 100, CurrentBalance = 200, AccountOpenDate = DateTime.Now },
        };
        }
        public async Task<bool> AddItemAsync(Customer customer)
        {
            customers.Add(customer);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = customers.Where((Customer arg) => arg.Id == new Guid(id)).FirstOrDefault();
            customers.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Customer> GetItemAsync(string id)
        {
            return await Task.FromResult(customers.FirstOrDefault(s => s.Id == new Guid(id)));
        }

        public async Task<IEnumerable<Customer>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(customers);
        }

        public async Task<bool> UpdateItemAsync(Customer item)
        {
            var oldItem = customers.Where((Customer arg) => arg.Id == item.Id).FirstOrDefault();
            customers.Remove(oldItem);
            customers.Add(item);

            return await Task.FromResult(true);
        }
    }
}
