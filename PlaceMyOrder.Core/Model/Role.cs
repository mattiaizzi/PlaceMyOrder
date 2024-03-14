using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Core.Model
{
    public enum Role
    {
        [Description("Cliente")]
        Customer = 1,
        [Description("Amministratore")]
        Admin = 2
    }
}
