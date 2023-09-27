using G_Pigmy.Models;

namespace G_Pigmy.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        private Agent Agent { get; set; }

        public HomeViewModel()
        {
            Agent = new Agent
            {
                Id = new System.Guid(),
                Name = "Daniel B. Whitener",
                AgentCode = "01168",
                Collection = 55000,
                Mobile = "1234567890",
                Commission = 1100,
                TotalCustomer = 100,
                VisitedCustomer = 40
            };
        }
    }
}
