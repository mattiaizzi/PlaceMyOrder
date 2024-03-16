using PlaceMyOrder.Core.Model;

namespace PlaceMyOrder.Core.Strategies.BillStrategy
{
    public interface IBillStrategy
    {
        double GetTotal(List<Meal> meals);
    }
}
