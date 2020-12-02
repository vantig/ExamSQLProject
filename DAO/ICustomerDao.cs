using System.Collections.Generic;
using ExamProject.Model.Entity;

namespace ExamProject.DAO
{
    public interface ICustomerDao
    {
        IList<Customer> GetAllCustomers();
        void InsertCustomer(Customer student);

        void DeleteCustomer(int id);

        void UpdateCustomer(Customer student, int id);

      
        Customer GetCustomer(int id);
    }
}
