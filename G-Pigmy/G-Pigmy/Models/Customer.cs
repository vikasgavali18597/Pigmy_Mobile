using System;

namespace G_Pigmy.Models
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AccountNumber { get; set; }

        public decimal CurrentBalance { get; set; }

        public decimal AvailableBalance { get; set; }

        public decimal Amount { get; set; }

        public DateTime AccountOpenDate { get; set; }

        public bool Status { get; set; }
    }
}
