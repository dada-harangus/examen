using Lab2Expense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2Expense.ViewModels
{
    public class PackagePostModel
    {
        public string CountryExpedition { get; set; }
        public string Sender { get; set; }
        public string CountryDestination { get; set; }
        public string Receiver { get; set; }
        public string Adress { get; set; }
        public double Cost { get; set; }
        public string Tracking { get; set; }

        public static Package ToPackage(PackagePostModel packagePostModel)
        {
            return new Package
            {
                CountryExpedition = packagePostModel.CountryExpedition,
                Sender = packagePostModel.Sender,
                CountryDestination = packagePostModel.CountryDestination,

                Receiver = packagePostModel.Receiver,
                Adress = packagePostModel.Adress,
                Cost = packagePostModel.Cost,
                Tracking = packagePostModel.Tracking

            };

        }

    }

}
