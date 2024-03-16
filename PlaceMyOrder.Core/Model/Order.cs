using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlaceMyOrder.Core.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public User Customer { get; set; }
        public DateTime CreationDate { get; set; }
        public int OrderNumber { get; set; }
        public Address Address { get; set; }
        public List<Meal> Meals { get; set; }
    }
}
