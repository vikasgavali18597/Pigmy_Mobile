using G_Pigmy.Models;
using G_Pigmy.Views;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace G_Pigmy.ViewModels
{
    //[QueryProperty(nameof(_id), nameof(_id))]
    public class CustomerViewModel : BaseViewModel
    {
        private Customer _selectedCustomer;

        public ICommand ButtonClickedCommand { get; set; }
       

        public ObservableCollection<Customer> Customers { get; }
        public Command LoadCustomersCommand { get; }
        public Command AddCustomerCommand { get; }
        public Command<Customer> CustomerTpped { get; }

        public ICommand ClearEntryCommand { get; private set; }





        Command<object> tapCommand;

        public Command<object> TapCommand { get { return tapCommand; } protected set { tapCommand = value; } }

        public IEnumerable<Customer> GetSearchedCustomers(string searchText = null)
        {
            return Customers.Where(p => p.Name.ToLower().StartsWith(searchText.ToLower()) || p.AccountNumber.ToLower().Contains(searchText.ToLower()));
        }




        public CustomerViewModel()
        {
            Title = "Customers";
            Customers = new ObservableCollection<Customer>
            {
                new Customer { Id = new Guid("94a2bc95-8174-439b-a1c9-1c6b4271626f"), Name = "Andrew Andrew Balbirnie", AccountNumber = "12341", AvailableBalance = 100, CurrentBalance = 200, AccountOpenDate = DateTime.Now, Status = false},
                new Customer { Id = new Guid("94a2bc95-8174-439b-a1c9-1c6b4271626f"), Name = "Paul Stirling ", AccountNumber = "12342", AvailableBalance = 2000, CurrentBalance = 2100, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid("94a2bc95-8174-439b-a1c9-1c6b4271626f"), Name = "Lorcan Tucker ", AccountNumber = "12343", AvailableBalance = 4500, CurrentBalance = 4700, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid("94a2bc95-8174-439b-a1c9-1c6b4271626f"), Name = "Harry Tector", AccountNumber = "12344", AvailableBalance = 50000, CurrentBalance = 50100, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid("94a2bc95-8174-439b-a1c9-1c6b4271626f"), Name = "Kavi O Brain", AccountNumber = "12345", AvailableBalance = 800, CurrentBalance =1000, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid("94a2bc95-8174-439b-a1c9-1c6b4271626f"), Name = "George Dockrell", AccountNumber = "12346", AvailableBalance = 1200, CurrentBalance = 2000, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid("94a2bc95-8174-439b-a1c9-1c6b4271626f"), Name = "Mark Adair", AccountNumber = "12347", AvailableBalance = 300, CurrentBalance = 5000, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Barry McCarthy", AccountNumber = "12348", AvailableBalance = 7800, CurrentBalance = 7900, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Craig Young", AccountNumber = "12349", AvailableBalance = 4000, CurrentBalance = 4200, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Joshua Little", AccountNumber = "12350", AvailableBalance = 40000, CurrentBalance = 41000, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Benjamin White", AccountNumber = "12351", AvailableBalance = 7800, CurrentBalance = 7900, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Fionn Hand", AccountNumber = "12352", AvailableBalance = 500, CurrentBalance = 700, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Theo van Woerkom", AccountNumber = "12353", AvailableBalance = 700, CurrentBalance = 900, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Gareth Delany", AccountNumber = "12354", AvailableBalance = 1080, CurrentBalance = 2100, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Ross Adair", AccountNumber = "12355", AvailableBalance = 2300, CurrentBalance = 2400, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Heinrich Malan", AccountNumber = "12356", AvailableBalance = 3000, CurrentBalance = 3500, AccountOpenDate = DateTime.Now , Status = false},
                new Customer { Id = new Guid(), Name = "Ryan Eagleson", AccountNumber = "12357", AvailableBalance = 900, CurrentBalance = 1200, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = "Gary Wilson", AccountNumber = "12358", AvailableBalance = 1000, CurrentBalance = 1100, AccountOpenDate = DateTime.Now, Status = false },
                new Customer { Id = new Guid(), Name = " Nathan Hauritz", AccountNumber = "12359", AvailableBalance = 100, CurrentBalance = 200, AccountOpenDate = DateTime.Now , Status = false},

            };

            ButtonClickedCommand = new Command<Customer>(OnButtonClicked);

            tapCommand = new Command<object>(OnTapped);

            LoadCustomersCommand = new Command(async () => await ExecuteLoadItemsCommand());

            CustomerTpped = new Command<Customer>(OnItemSelected);

            AddCustomerCommand = new Command(OnAddItem);

            ClearEntryCommand = new Command(ClearEntry);
        }

        private Expander _expander; 

        public Expander Expander 
        { 
            get { return _expander; }
            set
            {
                _expander = value;
                OnPropertyChanged(nameof(Expander));
            }
        }




        private string _entryText;
        public string EntryText
        {
            get { return _entryText; }
            set
            {
                _entryText = value;
                OnPropertyChanged(nameof(EntryText));
            }
        }

        private void ClearEntry()
        {
            Expander.IsExpanded = false;
        }
        private bool PopUp()
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
                    BackgroundColor = new Color(150, 150, 232, 0.14),
                    Children =
                    {

                         new Image
                         {
                             Source = "icon_about.png"
                         },

                         new Label
                         {
                              FontFamily="glab",
                              FontSize = 10,
                              VerticalOptions = LayoutOptions.Center,
                              HorizontalOptions = LayoutOptions.Center,
                              Text = "Are you sour to make this payment.?",
                              TextColor = Color.Black,
                              Margin = new Thickness(0,0,0,0),
                         },

                         new Xamarin.Forms.Button
                         {
                             Text = "Cancel",
                             WidthRequest = 100,

                             HorizontalOptions = LayoutOptions.Start,
                             Behaviors = {  },
                             Command = {  },
                         },

                         new Xamarin.Forms.Button
                         {
                             Text = "Reciept",
                             WidthRequest = 100,
                             Margin = new Thickness(2),
                             HorizontalOptions = LayoutOptions.End,
                             Command = {  },
                         },
                    }
                }
            };
            App.Current.MainPage.Navigation.ShowPopup(popup);

            return true;
        }

        private bool GetTrue(object sender, EventArgs e)
        {
            return true;
        }
        private async  void OnButtonClicked(Customer obj)
        {
            //var result = await Application.Current.MainPage.DisplayPromptAsync("Recipt", "Are you sour make this payment ..?", "Ok", "Cancel");

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


        public void OnTapped(object obj)
        {
            var id = (obj as Customer).Id;
            var alert = Application.Current.MainPage.DisplayAlert("Parameter Passed", "AccountNumber:" + id, "Cancel");
        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Customers.Clear();
                var items = await CustomerDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Customers.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedCustomer = null;
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                SetProperty(ref _selectedCustomer, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Customer item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(CustomerPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }

    }
}
