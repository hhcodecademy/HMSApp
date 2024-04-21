using HMSApp.Management;

namespace HMSApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManagememt customerManagememt = new CustomerManagememt();
            //customerManagememt.AddCustomer();
            HotelManagement hotelManagement = new HotelManagement();
            //var list = hotelManagement.GetHotels();
            //foreach (var hotel in list)
            //{
            //    Console.WriteLine(hotel.ToString());

            //}
            //hotelManagement.UpdateHotel();
            hotelManagement.DeleteHotel();
        }
    }
}
