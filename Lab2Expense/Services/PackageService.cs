using Lab2Expense.Models;
using Lab2Expense.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2Expense.Services
{
    public interface IPackageService
    {
        IEnumerable<PackageGetModel> GetAll();
        Package Create(PackagePostModel packagePostModel);
        Package Upsert(int id, PackagePostModel packagePostModel);
        Package Delete(int id);
        Package GetById(int id);
        IEnumerable<PackageGetModel> GetByExpeditor(string expeditor);
        IEnumerable<DestinatarViewModel> Filter();


    }
    public class PackageService : IPackageService
    {
        private ExpensesDbContext context;
        public PackageService(ExpensesDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<PackageGetModel> GetByExpeditor(string expeditor)
        {
            var result = context.Packages.Select(package => new PackageGetModel
            {
                Id = package.Id,
                CountryExpedition = package.CountryExpedition,
                Sender = package.Sender,
                CountryDestination = package.CountryDestination,
                Receiver = package.Receiver,
                Adress = package.Adress,
                Cost = package.Cost,
                Tracking = package.Tracking
            }).Where(package => package.Sender == expeditor).ToList();
            return result;
        }

        public Package Create(PackagePostModel packagePostModel)
        {
            Package toAdd = PackagePostModel.ToPackage(packagePostModel);


            context.Packages.Add(toAdd);
            context.SaveChanges();
            return toAdd;


        }
        public Package GetById(int id)
        {
            return context.Packages
                //.Include(e => e.Comments)
                .FirstOrDefault(e => e.Id == id);
        }
        public Package Delete(int id)
        {
            {
                var existing = context.Packages.FirstOrDefault(package => package.Id == id);
                if (existing == null)
                {
                    return null;
                }
                context.Packages.Remove(existing);
                context.SaveChanges();
                return existing;
            }

        }



        public IEnumerable<PackageGetModel> GetAll()
        {
            var result = context.Packages.Select(package => new PackageGetModel
            {
                Id = package.Id,
                CountryExpedition = package.CountryExpedition,
                Sender = package.Sender,
                CountryDestination = package.CountryDestination,
                Receiver = package.Receiver,
                Adress = package.Adress,
                Cost = package.Cost,
                Tracking = package.Tracking
            }).ToList();
            
            
            
            return result;
        }

        public IEnumerable<DestinatarViewModel> Filter()
        {
            var result = from pack in context.Packages
                         group pack by pack.Sender into playerGroup
                         select new DestinatarViewModel
                         {
                             name = playerGroup.Key,
                             cost = playerGroup.Sum(x => x.Cost),
                         
        };



            return result;
        }


        public Package Upsert(int id, PackagePostModel packagePostModel)
        {
            Package toAdd = PackagePostModel.ToPackage(packagePostModel);
            var existing = context.UserRole.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (existing == null)
            {

                context.
                    Packages.Add(toAdd);
                context.SaveChanges();
                return toAdd;
            }
            toAdd.Id = id;
            context.Packages.Update(toAdd);
            context.SaveChanges();
            return toAdd;
        }
    }
}
