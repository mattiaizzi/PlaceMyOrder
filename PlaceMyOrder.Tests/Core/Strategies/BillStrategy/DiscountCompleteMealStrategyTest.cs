

using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Core.Strategies.BillStrategy;

namespace PlaceMyOrder.Tests.Core.Strategies.BillStrategy
{
    public class DiscountCompleteMealStrategyTest
    {
        [Fact]
        public void TestCompleteMeal()
        {
            var strategy = new DiscountCompleteMealStrategy();
            var firstPrice = 7;
            var mainPrice = 10;
            var sidePrice = 4;
            var dessertPrice = 5;

            var meals = new List<Meal>()
            {
                new Meal { Name = "primo", Price = firstPrice, Course = Course.First },
                new Meal { Name = "secondo", Price = mainPrice, Course = Course.Main },
                new Meal { Name = "Dessert", Price = dessertPrice, Course = Course.Dessert },
                new Meal { Name = "Contorno", Price = sidePrice, Course = Course.Side },
            };

            double total = firstPrice + mainPrice + sidePrice + dessertPrice;
            double discountedPrice = total - ((total / 100) * 10);
            Assert.Equal(discountedPrice, strategy.GetTotal(meals));
        }

        [Fact]
        public void TestNotCompleteMeal()
        {
            var strategy = new DiscountCompleteMealStrategy();
            var firstPrice = 7;
            var mainPrice = 10;
            var dessertPrice = 5;

            var meals = new List<Meal>()
            {
                new Meal { Name = "primo", Price = firstPrice, Course = Course.First },
                new Meal { Name = "secondo", Price = mainPrice, Course = Course.Main },
                new Meal { Name = "Dessert", Price = dessertPrice, Course = Course.Dessert },
            };

            double total = firstPrice + mainPrice + dessertPrice;
            Assert.Equal(total, strategy.GetTotal(meals));
        }

        [Fact]
        public void TestTwoCompleteMeal()
        {
            var strategy = new DiscountCompleteMealStrategy();
            var firstPrice = 7;
            var mainPrice = 10;
            var sidePrice = 4;
            var dessertPrice = 5;

            var firstPriceTwo = 9;
            var mainPriceTwo = 15;
            var sidePriceTwo = 3;
            var dessertPriceTwo = 3;

            var meals = new List<Meal>()
            {
                new Meal { Name = "primo", Price = firstPrice, Course = Course.First },
                new Meal { Name = "secondo", Price = mainPrice, Course = Course.Main },
                new Meal { Name = "Dessert", Price = dessertPrice, Course = Course.Dessert },
                new Meal { Name = "Contorno", Price = sidePrice, Course = Course.Side },

                new Meal { Name = "primo", Price = firstPriceTwo, Course = Course.First },
                new Meal { Name = "secondo", Price = mainPriceTwo, Course = Course.Main },
                new Meal { Name = "Dessert", Price = dessertPriceTwo, Course = Course.Dessert },
                new Meal { Name = "Contorno", Price = sidePriceTwo, Course = Course.Side },
            };

            double totalFirst = firstPrice + mainPrice + sidePrice + dessertPrice;
            double discountedPriceFirst = totalFirst - ((totalFirst / 100) * 10);

            double totalTwo = firstPriceTwo + mainPriceTwo + sidePriceTwo + dessertPriceTwo;
            double discountedPriceTwo = totalTwo - ((totalTwo / 100) * 10);

            Assert.Equal(discountedPriceFirst + discountedPriceTwo, strategy.GetTotal(meals));
        }


        [Fact]
        public void TestTwoCompleteMealAndOtherDishes()
        {
            var strategy = new DiscountCompleteMealStrategy();

            var firstPriceTwo = 9;
            var firstPriceThree = 8;
            var firstPrice = 7;

            var mainPriceTwo = 15;
            var mainPrice = 10;
            var mainPriceThree = 9;

            var sidePrice = 4;
            var sidePriceTwo = 3;

            var dessertPrice = 5;
            var dessertPriceTwo = 3;

            var meals = new List<Meal>()
            {
                new Meal { Name = "primo", Price = firstPrice, Course = Course.First },
                new Meal { Name = "secondo", Price = mainPrice, Course = Course.Main },
                new Meal { Name = "Dessert", Price = dessertPrice, Course = Course.Dessert },
                new Meal { Name = "Contorno", Price = sidePrice, Course = Course.Side },

                new Meal { Name = "primo", Price = firstPriceTwo, Course = Course.First },
                new Meal { Name = "secondo", Price = mainPriceTwo, Course = Course.Main },
                new Meal { Name = "Dessert", Price = dessertPriceTwo, Course = Course.Dessert },
                new Meal { Name = "Contorno", Price = sidePriceTwo, Course = Course.Side },

                new Meal { Name = "primo", Price = firstPriceThree, Course = Course.First },
                new Meal { Name = "secondo", Price = mainPriceThree, Course = Course.Main },
            };
            // Sommo prima il menu completo con i prezzi più costosi
            double totalFirst = firstPriceTwo + mainPriceTwo + sidePrice + dessertPrice;
            double discountedPriceFirst = totalFirst - ((totalFirst / 100) * 10);

            // Sommo il secondo menu completo con i prezzi più costosi ad esclusione di quelli precedenti
            double totalTwo = firstPriceThree + mainPrice + sidePriceTwo + dessertPriceTwo;
            double discountedPriceTwo = totalTwo - ((totalTwo / 100) * 10);

            // Sommo al totale dei due menu i pasti rimanenti
            Assert.Equal(discountedPriceFirst + discountedPriceTwo + firstPrice + mainPriceThree, strategy.GetTotal(meals));
        }
    }
}
