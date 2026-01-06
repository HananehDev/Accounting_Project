using Accounting.DataLayer.Repositories;
using Accounting.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        //Accounting_DBEntities3 db = new Accounting_DBEntities3();    
        private Accounting_DBEntities3 db;                             // Constructor injection
        public CustomerRepository(Accounting_DBEntities3 context)
        {
            db= context;    
        }
        //---------------------------------
        public List<Customers> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public bool DeleteCustomer(Customers customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(int customerID)
        {
            try
            {
                var res = GetCustomersbyID(customerID);
                DeleteCustomer(res);
                return true;
            }
            catch
            {
                return false;
            }

        }


        public Customers GetCustomersbyID(int customerID)
        {
            return db.Customers.Find(customerID);
        }

        public bool InsertCustomer(Customers customer)
        {
            try
            {
                db.Customers.Add(customer);
                return true;
            }
            catch
            {
                return false;
            }

        }


        public bool UpdateCustomer(Customers customer)
        {
            //try
            //{
            //    db.Entry(customer).State = EntityState.Modified;
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
            //----------------------------
            var local = db.Set<Customers>()                               // we could use using instead thease code
                         .Local
                         .FirstOrDefault(f => f.customerID == customer.customerID);
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            //-----------------------------
            db.Entry(customer).State = EntityState.Modified;
            return true;
        }

        //public void Save()
        //{
        //    db.SaveChanges();
        //}

        public IEnumerable<Customers> GetCustomersByFilter(string parameter)
        {
            return db.Customers.Where(c => c.FullName.Contains(parameter) || c.Email.Contains(parameter) || c.Mobile.Contains(parameter));
        }


        List<ListCustomerViewModel> ICustomerRepository.GetCustomerNames(string filter)
        {
            if (filter == null)
            {
                return db.Customers.Select(c =>new ListCustomerViewModel()
                {
                    CustomerId = c.customerID,
                    FullName = c.FullName
                }).ToList();
            }
            return db.Customers.Where(c => c.FullName.Contains(filter)).Select(c => new ListCustomerViewModel()
            {
                FullName = c.FullName
            }).ToList();
        }

        public int GetCustomerIdByName(string name)
        {
            return db.Customers.First(c => c.FullName == name).customerID;
        }

        public string GetCustomerNameByID(int CustomerId)
        {
            return db.Customers.Find(CustomerId).FullName;
        }
    }
}
