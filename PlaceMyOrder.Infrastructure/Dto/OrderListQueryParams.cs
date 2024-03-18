using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Infrastructure.Dto
{
    public class OrderListQueryParams : PageableRequestDto
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public Guid UserId { get; set; }
    }
}
