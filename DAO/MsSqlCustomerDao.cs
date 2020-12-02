using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ExamProject.Model.Entity;

namespace ExamProject.DAO
{
    public class MsSqlCustomerDao : MsSqlAbstractDao, ICustomerDao
    {
        private const string SELECT_ALL_CUSTOMERS = "SELECT * FROM Customers";
        private const string SELECT_CUSTOMER = "SELECT * FROM Customers WHERE ID = @id";
        private const string INSERT_CUSTOMER = "INSERT INTO Customers(FirstName, LastName,Address, Сard_number, Bank_account_number,Money) VALUES(@firstName, @lastName, @address, @cardNumber,@bankAccountNumber,@Money)";
        private const string UPDATE_CUSTOMER = "UPDATE Customers SET FirstName= @firstName, LastName = @lastName, " +
            "Address = @address,Сard_number = @cardNumber,Bank_account_number=@bankAccountNumber ,Money=@money WHERE ID = @id";
        private const string DELETE_CUSTOMER = "DELETE FROM Customers WHERE ID = @id";



        public IList<Customer> GetAllCustomers()
        {

            IList<Customer> list = new List<Customer>();

            SqlConnection connection = (SqlConnection)GetConnection();

            SqlCommand sqlCommand = new SqlCommand(SELECT_ALL_CUSTOMERS, connection);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    if (!reader.IsDBNull(1))
                    {
                        customer.FirstName = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        customer.LastName = reader.GetString(2);
                    }

                    if (!reader.IsDBNull(3))
                    {
                        customer.Address = reader.GetString(3);
                    }

                    if (!reader.IsDBNull(4))
                    {
                        customer.CardNumber = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        customer.BankAccountNumber = reader.GetString(5);
                    }

                    customer.Money = reader.GetInt32(6);
                    list.Add(customer);
                }
            }

            ReleaseConnection(connection);

            return list;
        }

        public void InsertCustomer(Customer customer)
        {
            // private const string INSERT_CUSTOMER = "INSERT INTO Customers(firstName, lastName,address, cardNumber, bankAccountNumber,Money) VALUES(@firstName, @lastName, @address, @cardNumber,@bankAccountNumber,@money)";

            SqlConnection sqlConnection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand(INSERT_CUSTOMER, sqlConnection);

            SqlParameter firstNameParam = new SqlParameter
            {
                Value = customer.FirstName,
                ParameterName = "@firstName",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input
            };

            cmd.Parameters.Add(firstNameParam);

            SqlParameter lastNameParam = new SqlParameter
            {
                Value = customer.LastName,
                ParameterName = "@lastName",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input
            };

            cmd.Parameters.Add(lastNameParam);
            SqlParameter addressParam = new SqlParameter
            {
                Value = customer.Address,
                ParameterName = "@address",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input
            };

            cmd.Parameters.Add(addressParam);

            SqlParameter cardNumberParam = new SqlParameter
            {
                Value = customer.CardNumber,
                ParameterName = "@cardNumber",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input
            };

            cmd.Parameters.Add(cardNumberParam);



            SqlParameter bankAccountNumberParam = new SqlParameter
            {
                Value = customer.BankAccountNumber,
                ParameterName = "@bankAccountNumber",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input
            };
            cmd.Parameters.Add(bankAccountNumberParam);

            SqlParameter moneyParam = new SqlParameter
            {
                Value = customer.Money,
                ParameterName = "@money",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            cmd.Parameters.Add(moneyParam);


            cmd.ExecuteNonQuery();

            ReleaseConnection(sqlConnection);
        }

        public void DeleteCustomer(int id)
        {
            //        private const string DELETE_CUSTOMER = "DELETE FROM Customer WHERE ID = @id";
            SqlConnection sqlConnection = (SqlConnection)GetConnection();

            SqlCommand sqlCommand = new SqlCommand(DELETE_CUSTOMER, sqlConnection);

            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@id",
                Value = id,
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int
            };

            sqlCommand.Parameters.Add(idParam);

            sqlCommand.ExecuteNonQuery();

            ReleaseConnection(sqlConnection);
        }

        public void UpdateCustomer(Customer customer, int id)
        {
            SqlConnection sqlConnection = (SqlConnection)GetConnection();

            SqlCommand cmd = new SqlCommand(UPDATE_CUSTOMER, sqlConnection);

            SqlParameter firstNameParam = new SqlParameter
            {
                Value = customer.FirstName,
                ParameterName = "@firstName",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input
            };

            cmd.Parameters.Add(firstNameParam);

            SqlParameter lastNameParam = new SqlParameter
            {
                Value = customer.LastName,
                ParameterName = "@lastName",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input
            };

            cmd.Parameters.Add(lastNameParam);
            SqlParameter addressParam = new SqlParameter
            {
                Value = customer.Address,
                ParameterName = "@address",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input
            };

            cmd.Parameters.Add(addressParam);

            SqlParameter cardNumberParam = new SqlParameter
            {
                Value = customer.CardNumber,
                ParameterName = "@cardNumber",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input
            };

            cmd.Parameters.Add(cardNumberParam);



            SqlParameter bankAccountNumberParam = new SqlParameter
            {
                Value = customer.BankAccountNumber,
                ParameterName = "@bankAccountNumber",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input
            };
            cmd.Parameters.Add(bankAccountNumberParam);

            SqlParameter moneyParam = new SqlParameter
            {
                Value = customer.Money,
                ParameterName = "@money",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            cmd.Parameters.Add(moneyParam);

            SqlParameter idParam = new SqlParameter
            {
                Value = id,
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            cmd.Parameters.Add(idParam);

            cmd.ExecuteNonQuery();

            ReleaseConnection(sqlConnection);
        }

        public Customer GetCustomer(int id)
        {
            SqlConnection sqlConnection = (SqlConnection)GetConnection();

            SqlCommand sqlCommand = new SqlCommand(SELECT_CUSTOMER, sqlConnection);
            SqlParameter idParam = new SqlParameter
            {
                Value = id,
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input
            };
            sqlCommand.Parameters.Add(idParam);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            reader.Read();
            Customer customer = new Customer();
            if (!reader.IsDBNull(1))
            {
                customer.FirstName = reader.GetString(1);
            }
            if (!reader.IsDBNull(2))
            {
                customer.LastName = reader.GetString(2);
            }

            if (!reader.IsDBNull(3))
            {
                customer.Address = reader.GetString(3);
            }

            if (!reader.IsDBNull(4))
            {
                customer.CardNumber = reader.GetString(4);
            }

            if (!reader.IsDBNull(5))
            {
                customer.BankAccountNumber = reader.GetString(5);
            }
            customer.Money = reader.GetInt32(6);





            return customer;
        }
    }
}
