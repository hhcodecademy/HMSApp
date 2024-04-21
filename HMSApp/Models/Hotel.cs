using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSApp.Models
{
    internal class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public override string? ToString()
        {
            string newtext =$"Hotel id: {this.Id} name: {this.Name} ContactName: {this.ContactName} Phone: {this.Phone} Email: {this.Email} Address:{this.Address}";
            return newtext;
        }
    }
}
