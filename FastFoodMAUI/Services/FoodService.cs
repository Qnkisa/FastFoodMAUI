using FastFoodMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodMAUI.Services
{
    public class FoodService
    {
        private readonly static IEnumerable<Food> _foods = new List<Food>
        {
            new Food
            {
                Name = "Ayrian",
                Image = "ayrian.png",
                Price = 1.5,
                Description = "Refresh yourself with a traditional, cool, and creamy yogurt-based drink. Perfect for pairing with any meal, Ayrian offers a tangy yet smooth taste that balances spice and flavor. Ideal for hydration and enhancing your dining experience."
            },
            new Food
            {
                Name = "Burger",
                Image = "burger.png",
                Price = 6.5,
                Description = "A delicious classic, our burger features a juicy, perfectly grilled patty topped with fresh lettuce, tomatoes, and cheese, all served in a soft bun. It's the ultimate comfort food for any occasion, guaranteed to satisfy your cravings."
            },
            new Food
            {
                Name = "Chicken Nuggets",
                Image = "chicken_nuggets.png",
                Price = 6,
                Description = "Crispy on the outside and tender on the inside, our chicken nuggets are the perfect snack or side. Made with high-quality chicken and coated in a crunchy breading, they’re perfect for dipping in your favorite sauce."
            },
            new Food
            {
                Name = "Doner Kebab",
                Image = "doner_kebab.png",
                Price = 7,
                Description = "Indulge in a flavorful, savory experience with our doner kebab. Tender slices of seasoned meat are paired with fresh veggies, wrapped in warm pita, and drizzled with your choice of sauces. A satisfying meal on the go."
            },
            new Food
            {
                Name = "Fizzy Drink",
                Image = "fizzy_drink.png",
                Price = 2,
                Description = "Refresh your taste buds with a crisp, bubbly fizzy drink. Perfectly sweet and effervescent, it’s the ideal complement to any meal, quenching your thirst while adding a little sparkle to your day."
            },
            new Food
            {
                Name = "French Fries",
                Image = "french_fries.png",
                Price = 3,
                Description = "Golden, crispy, and perfectly seasoned, our French fries are a fan favorite. Served hot and fresh, they’re the perfect side to any meal, offering a satisfying crunch with each bite. A classic that never disappoints."
            },
            new Food
            {
                Name = "Hot Dog",
                Image = "hot_dog.png",
                Price = 4.5,
                Description = "Savor a plump, flavorful sausage served in a soft bun and topped with your favorite condiments. Our hot dog is a quick, delicious meal or snack, perfect for anyone craving something hearty and satisfying."
            },
            new Food
            {
                Name = "Meatballs",
                Image = "meatballs.png",
                Price = 5.5,
                Description = "Tender, juicy meatballs served in a rich tomato sauce, delivering a burst of flavor with every bite. Made with a blend of premium meats and spices, these meatballs are a comforting, filling option that will leave you craving more."
            },
            new Food
            {
                Name = "Pizza",
                Image = "pizza.png",
                Price = 3,
                Description = "A mouthwatering combination of golden, crispy crust, gooey cheese, and savory toppings, our pizza is perfect for sharing. Choose from a variety of flavors, each one baked to perfection with fresh ingredients and bold taste."
            },
            new Food
            {
                Name = "Skewer",
                Image = "skewer.png",
                Price = 10,
                Description = "Grilled to perfection, our skewer features juicy pieces of marinated meat, expertly seasoned for maximum flavor. Served with fresh veggies and a smoky finish, it’s a satisfying, protein-packed meal that’s both delicious and filling."
            }
        };

        public IEnumerable<Food> GetAllFoods() => _foods;

        public IEnumerable<Food> GetPopularFoods(int count = 6) => _foods.OrderBy(f => Guid.NewGuid()).Take(count);

        public IEnumerable<Food> SearchFoods(string searchTerm) =>
            string.IsNullOrWhiteSpace(searchTerm) ? _foods : 
            _foods.Where(f => f.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}
