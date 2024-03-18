﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Infrastructure.Dto
{
    public abstract class PageableRequestDto
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}