using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMSApp.ADO;
using HMSApp.Models;

namespace HMSApp.Management
{
    internal class HotelManagement
    {
        public void AddHotel()
        {
            Hotel hotel = new Hotel();
            Console.Write("Enter hotel name: ");
            hotel.Name = Console.ReadLine();
            Console.Write("Enter hotel contact name: ");
            hotel.ContactName = Console.ReadLine();
            Console.Write("Enter hotel contact phone: ");
            hotel.Phone = Console.ReadLine();
            Console.Write("Enter hotel contact e-mail: ");
            hotel.Email = Console.ReadLine();
            Console.Write("Enter hotel address: ");
            hotel.Address = Console.ReadLine();

            using (SqlConnection con = CustomSQLConnection.Connect())
            {
                string querry = @"insert into [dbo].[Hotels] (Name,ContactName,Phone,Email,Address)
                                values (@htl_name,@htl_conName,@htl_phone,@htl_email,@htl_address)";
                SqlCommand cmd = new SqlCommand(querry,con);
                cmd.Parameters.AddWithValue("@htl_name", hotel.Name);
                cmd.Parameters.AddWithValue("@htl_conName",hotel.ContactName);
                cmd.Parameters.AddWithValue("@htl_phone", hotel.Phone);
                cmd.Parameters.AddWithValue("@htl_email", hotel.Email);
                cmd.Parameters.AddWithValue("@htl_address", hotel.Address);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Records Inserted Successfully");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    con.Close();
                    Console.ReadKey();
                }
            }

        }
        public List<Hotel> GetHotels()
        {
            List<Hotel> hotels = new List<Hotel>();

           
           
            using (SqlConnection conn= CustomSQLConnection.Connect())
            {
                string query = "select * from [dbo].[Hotels]";
                conn.Open();
                SqlCommand command= new SqlCommand(query,conn);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Hotel hotel = new Hotel();
                        hotel.Id = int.Parse(reader[0].ToString());
                        hotel.Name = reader[1].ToString();
                        hotel.ContactName = reader[2].ToString();
                        hotel.Phone = reader[3].ToString();
                        hotel.Email = reader[4].ToString();
                        hotel.Address = reader[0].ToString();
                        hotels.Add(hotel);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {

                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally {
                    conn.Close();
                }

          
            }
            return hotels;
                            

        }
        public void UpdateHotel()
        {
            Console.WriteLine("Enter hotel id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter hotel contact phone: ");
            string phone = Console.ReadLine();
            Console.Write("Enter hotel contact e-mail: ");
            string email = Console.ReadLine();

            using (SqlConnection con = CustomSQLConnection.Connect())
            {
                string querry = @"update [dbo].[Hotels] set Phone = @htl_phone , Email = @htl_email where id = @htl_id;";
                SqlCommand cmd = new SqlCommand(querry, con);
                cmd.Parameters.AddWithValue("@htl_id", id);
                cmd.Parameters.AddWithValue("@htl_email", email);
                cmd.Parameters.AddWithValue("@htl_phone", phone);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Records Updated Successfully");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    con.Close();
                    Console.ReadKey();
                }
            }
        }


        public void DeleteHotel()
        {
            Console.WriteLine("Enter hotel id: ");
            int id = int.Parse(Console.ReadLine());
           

            using (SqlConnection con = CustomSQLConnection.Connect())
            {
                string querry = @"delete [dbo].[Hotels] where id=@htl_id;";
                SqlCommand cmd = new SqlCommand(querry, con);
                cmd.Parameters.AddWithValue("@htl_id", id);
               
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Records Deleted Successfully");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    con.Close();
                    Console.ReadKey();
                }
            }
        }
    }
}
