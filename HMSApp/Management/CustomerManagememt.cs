using HMSApp.ADO;
using HMSApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSApp.Management
{
    internal class CustomerManagememt
    {
        public void AddCustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("enter name");
            customer.Name = Console.ReadLine();
            Console.WriteLine("enter surname");
            customer.Surname = Console.ReadLine();
            Console.WriteLine("enter fathername");
            customer.Fathername = Console.ReadLine();
            Console.WriteLine("enter phone number");
            customer.PhoneNumber = Console.ReadLine();
            Console.WriteLine("enter email");
            customer.Email = Console.ReadLine();

            using (SqlConnection conn = CustomSQLConnection.Connect())
            {



                string query = @"insert into [dbo].[Customers] (Name,Surname,Fathername,PhoneNumber,Email)
                                 values (@cst_name,@cst_surname,@cst_fathername,@cst_phone,@cst_email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                //Pass values to Parameters
                cmd.Parameters.AddWithValue("@cst_name", customer.Name);
                cmd.Parameters.AddWithValue("@cst_surname", customer.Surname);
                cmd.Parameters.AddWithValue("@cst_fathername", customer.Fathername);
                cmd.Parameters.AddWithValue("@cst_phone", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@cst_email", customer.Email);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Records Inserted Successfully");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    conn.Close();
                    Console.ReadKey();
                }

            }

        }
    }
}
