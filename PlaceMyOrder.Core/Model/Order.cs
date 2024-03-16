using PlaceMyOrder.Core.Strategies.BillStrategy;
using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlaceMyOrder.Core.Model
{
    public class Order
    {
        IBillStrategy billStrategy = new SimpleBillStrategy();
        public Guid Id { get; set; }
        public User Customer { get; set; }
        public DateTime CreationDate { get; set; }
        public int OrderNumber { get; set; }
        public Address Address { get; set; }
        public List<Meal> Meals { get; set; }

        public void SetBillStrategy(IBillStrategy billStrategy)
        {
            if (billStrategy != null)
            {
                this.billStrategy = billStrategy;
            }
        }

        public double Total
        {
            get
            {
                return billStrategy.GetTotal(Meals);
            }
        }


    }
}
