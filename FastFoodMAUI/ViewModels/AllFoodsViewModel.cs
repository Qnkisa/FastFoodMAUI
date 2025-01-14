using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodMAUI.ViewModels
{
    [QueryProperty(nameof(FromSearch), nameof(FromSearch))]
    public partial class AllFoodsViewModel : ObservableObject
    {
        private readonly FoodService _foodService;
        public AllFoodsViewModel(FoodService foodService)
        {
            _foodService = foodService;
            Foods = new(_foodService.GetAllFoods());
        }

        public ObservableCollection<Food> Foods { get; set; }

        [ObservableProperty]
        private bool _fromSearch;

        [ObservableProperty]
        private bool _searching;

        [RelayCommand]
        private async Task SearchFoods(string searchTerm)
        {
            Foods.Clear();
            Searching = true;
            await Task.Delay(1000);
            foreach (var food in _foodService.SearchFoods(searchTerm))
            {
                Foods.Add(food);
            }

            Searching = false;
        }

        [RelayCommand]
        private async Task GoToDetailsPage(Food food)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailsViewModel.Food)] = food
            };
            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }
    }
}
