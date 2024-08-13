using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.Models
{
    public class Stores
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StoreNumber { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Status { get; set; }
        public string StatusText
        {
            get
            {
                return this.Status == true ? "Open" : "Close";
            }
        }
   
        public string Address { get; set; } 
        public string PhoneNumber { get; set; }        
    
    }
}
