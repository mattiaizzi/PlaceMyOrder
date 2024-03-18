using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Infrastructure.Dto
{
    public abstract class PageableRequestDto
    {
        [Range(1, int.MaxValue)]
        public int? Page { get; set; }
        [Range(1, int.MaxValue)]
        public int? Size { get; set; }
    }
}
