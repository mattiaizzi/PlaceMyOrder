namespace PlaceMyOrder.Core.Model
{
    public class Meal
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public Double Price { get; set; }

        public Course Course { get; set; }
    }
}