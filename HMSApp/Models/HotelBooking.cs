using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSApp.Models
{
    internal class HotelBooking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }

    }
}
