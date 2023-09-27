﻿using Android.Net.Wifi.Aware;
using System;

namespace G_Pigmy.Models
{
    public class Statement
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public decimal Deposite { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
