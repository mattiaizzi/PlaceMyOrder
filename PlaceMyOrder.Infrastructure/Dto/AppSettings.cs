using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Infrastructure.Dto
{
    public class AppSettings
    {
        public string JwtSecret { get; set; } = string.Empty;
    }
}
