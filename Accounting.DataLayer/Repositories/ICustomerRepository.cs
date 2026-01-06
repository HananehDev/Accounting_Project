using Accounting.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Repositories
{
    public interface ICustomerRepository
    {
        List<Customers> GetAllCustomers();
        List<ListCustomerViewModel> GetCustomerNames(string filter=null);
        Customers GetCustomersbyID(int customerID);
        bool InsertCustomer(Customers customer);
        bool UpdateCustomer(Customers customer);
        bool DeleteCustomer(Customers customer);
        bool DeleteCustomer(int customerID);

        IEnumerable<Customers> GetCustomersByFilter(string parameter);

        int GetCustomerIdByName(string name);

        string GetCustomerNameByID(int CustomerId);

        

        //void Save();



    }
}
