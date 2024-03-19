using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Core.Exceptions
{
    public class MealNotFoundException : Exception
    {
        public MealNotFoundException()
        {
        }

        public MealNotFoundException(string message)
            : base(message)
        {
        }
    }
}
