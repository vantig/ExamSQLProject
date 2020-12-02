using System.Collections.Generic;
using ExamProject.Model.Entity;

namespace ExamProject.Model.Logic
{
    public class CustomerManager
    {
        public static List<Customer> MaxMoneyCustomers(IEnumerable<Customer> list)
        {
            int max = 0;

            IEnumerator<Customer> iterator = list.GetEnumerator();
            List<Customer>maxMoneyCustomers=new List<Customer>();
            while (iterator.MoveNext())
            {
                if (iterator.Current != null)
                {
                    if (iterator.Current.Money > max)
                    {
                        max = iterator.Current.Money;
                    }
                }
            }
            iterator.Reset();
            while (iterator.MoveNext())
            {
                if (iterator.Current != null)
                {
                    if (iterator.Current.Money ==max)
                    {
                      maxMoneyCustomers.Add(iterator.Current);
                    }
                }
            }

            return maxMoneyCustomers;
        }

    }
}
