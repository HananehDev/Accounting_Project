using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using Accounting.DataLayer.Repositories;
using Accounting.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Accounting_DBEntities3 db = new Accounting_DBEntities3();      // Constructor injection
            //ICustomerRepository customer = new CustomerRepository(db);     // polymorphism

            //Customers AddCustomer = new Customers()
            //{
            //    FullName = "حنانه ",
            //    Mobile = "098777",
            //    Email = "HAna@gamil.com",
            //    Address = "تهران ",
            //    CustomerImage = " No"
            //};
            //customer.InsertCustomer(AddCustomer);
            //customer.Save();
            //var list = customer.GetAllCustomers();

            UnitOfWork db = new UnitOfWork();
            var list =db.CustomerRepository.GetAllCustomers();
        }
    }
}
