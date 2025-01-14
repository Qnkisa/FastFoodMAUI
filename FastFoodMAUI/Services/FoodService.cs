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
                Price = 1.5
            },
            new Food
            {
                Name = "Burger",
                Image = "burger.png",
                Price = 6.5
            },
            new Food
            {
                Name = "Chicken Nuggets",
                Image = "chicken_nuggets.png",
                Price = 6
            },
            new Food
            {
                Name = "Doner Kebab",
                Image = "doner_kebab.png",
                Price = 7
            },
            new Food
            {
                Name = "Fizzy Drink",
                Image = "fizzy_drink.png",
                Price = 2
            },
            new Food
            {
                Name = "French Fries",
                Image = "french_fries.png",
                Price = 3
            },
            new Food
            {
                Name = "Hot Dog",
                Image = "hot_dog.png",
                Price = 4.5
            },
            new Food
            {
                Name = "Meatballs",
                Image = "meatballs.png",
                Price = 5.5
            },
            new Food
            {
                Name = "Pizza",
                Image = "pizza.png",
                Price = 3
            },
            new Food
            {
                Name = "Skewer",
                Image = "skewer.png",
                Price = 10
            }
        };

        public IEnumerable<Food> GetAllFoods() => _foods;

        public IEnumerable<Food> GetPopularFoods(int count = 6) => _foods.OrderBy(f => Guid.NewGuid()).Take(count);

        public IEnumerable<Food> SearchFoods(string searchTerm) =>
            string.IsNullOrWhiteSpace(searchTerm) ? _foods : 
            _foods.Where(f => f.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}
