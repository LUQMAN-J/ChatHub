using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch.ApiModels
{
    public class Authentication
    {
        public string token { get; set; }
        public string expiration { get; set; }
    }
}
