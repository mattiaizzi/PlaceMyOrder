using Microsoft.IdentityModel.Tokens;
using PlaceMyOrder.Core.Model;

namespace PlaceMyOrder.Core.Strategies.BillStrategy
{
    public class DiscountCompleteMealStrategy : IBillStrategy
    {
        private readonly int DISCOUNT_PERCENTAGE = 10;
        public double GetTotal(List<Meal> meals)
        {
            var dictionary = createCourseDictionary();
            foreach (var meal in meals)
            {
                dictionary[meal.Course].Add(meal);
                dictionary[meal.Course].OrderBy(meal => meal.Price);
            }

            return calculatePrice(dictionary);

        }

        private double calculatePrice(Dictionary<Course, List<Meal>> dictionary)
        {
            if (isToDiscount(dictionary))
            {
                var discountPrice = popExpansiveForEachCourseAndGetDiscounPrice(dictionary);
                return discountPrice + calculatePrice(dictionary);
            }
            else
            {
                var total = 0.00;
                foreach (var entry in dictionary)
                {
                    total += entry.Value.Sum(meal => meal.Price);
                }
                return total;
            }
        }

        private double popExpansiveForEachCourseAndGetDiscounPrice(Dictionary<Course, List<Meal>> dictionary)
        {
            var total = 0.00;
            foreach (var entry in dictionary)
            {
                var mostExpansive = entry.Value.Last();
                total += mostExpansive.Price;
                entry.Value.Remove(mostExpansive);
            }
            return total - total / 100 * DISCOUNT_PERCENTAGE;
        }

        private bool isToDiscount(Dictionary<Course, List<Meal>> dictionary)
        {
            foreach (var entry in dictionary)
            {
                if (entry.Value.IsNullOrEmpty())
                {
                    return false;
                }
            }
            return true;
        }

        private Dictionary<Course, List<Meal>> createCourseDictionary()
        {
            Dictionary<Course, List<Meal>> dictionary = new Dictionary<Course, List<Meal>>();
            foreach (Course course in Enum.GetValues(typeof(Course)))
            {
                dictionary.Add(course, new List<Meal>());
            }
            return dictionary;
        }
    }
}
