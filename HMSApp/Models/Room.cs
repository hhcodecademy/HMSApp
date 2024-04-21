using HMSApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HMSApp.Models
{
    internal class Room
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public RoomType Type { get; set; }
        public decimal Price { get; set; }
        public int HotelId { get; set; }

    }
}
