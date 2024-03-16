using PlaceMyOrder.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Core.Strategies.BillStrategy
{
    public class SimpleBillStrategy : IBillStrategy
    {
        public double GetTotal(List<Meal> meals)
        {
            return meals.Sum(meal => meal.Price);
        }
    }
}
