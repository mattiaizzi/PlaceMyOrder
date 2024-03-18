using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Infrastructure.Dto
{
    public class PageableResponseDto<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int PageCount { get; set; }
        public int ElementCount { get; set; }
        public List<T> Items { get; set; }

    }
}
