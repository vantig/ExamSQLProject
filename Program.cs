using System;
using System.Collections.Generic;
using ExamProject.DAO;
using ExamProject.Model.Entity;
using ExamProject.Model.Logic;

namespace ExamProject
{
    class Program
    {
        static void Main()
        {
            ICustomerDao customerDao = new MsSqlCustomerDao();

            Customer customer = new Customer("Ivan", "Gordeychik", "Tolstogo 4", "1234432167899876", "BA123456789098764321", 100);

            //customerDao.InsertCustomer(customer);
            Console.Read();
            IList<Customer> list = customerDao.GetAllCustomers();

            foreach (Customer cust in list)
            {
                Console.WriteLine(cust);
            }
            Customer newcustomer = new Customer("Ivan", "Gordeychik", "Tolstogo 4", "1234432167899876", "BA123456789098764321", 800);
            customerDao.UpdateCustomer(newcustomer, 8);


            list = customerDao.GetAllCustomers();
            var maxMoneyCustomers = CustomerManager.MaxMoneyCustomers(list);

            Console.WriteLine("MaxMoneyCustomers:");
            foreach (Customer cust in maxMoneyCustomers)
            {
                Console.WriteLine(cust);
            }

            Console.Read();
            customerDao.DeleteCustomer(7);

            Console.Read();
        }
    }
}
