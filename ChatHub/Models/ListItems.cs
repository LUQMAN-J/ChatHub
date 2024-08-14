using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatHub.Models
{
    public partial class Suggestions : ObservableObject
    {
        [ObservableProperty]
        public string name;
    }
}
