using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2Expense.ViewModels
{
    public class PackageGetModel
    {   public int Id { get; set; }
        public string CountryExpedition { get; set; }
        public string Sender { get; set; }
        public string CountryDestination { get; set; }
        public string Receiver { get; set; }
        public string Adress { get; set; }
        public double Cost { get; set; }
        public string Tracking { get; set; }
    }
}
