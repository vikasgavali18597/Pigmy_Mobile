using Android.Hardware.Camera2;
using Android.Icu.Number;
using System;
using System.Collections.Generic;
using System.Text;

namespace G_Pigmy.Models
{
    class Agent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AgentCode { get; set; }

        public string Mobile { get; set; }

        public decimal Collection { get; set; }

        public decimal Commission { get; set; }

        public long TotalCustomer { get; set; }

        public long VisitedCustomer { get; set; }


    }
}
