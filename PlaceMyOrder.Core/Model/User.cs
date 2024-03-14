using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Core.Model
{
    public class User
    {
        public String Email { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Password { get; set; }
        public Role Role { get; set; }
    }
}
