using CommunityToolkit.Mvvm.ComponentModel;
using FastFoodMAUI.Models;
using FastFoodMAUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodMAUI.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly FoodService _foodService;
        public HomeViewModel(FoodService foodService)
        {
            _foodService = foodService;
            Foods = new(_foodService.GetPopularFoods());
        }

        public ObservableCollection<Food> Foods { get; set; }

        [RelayCommand]
        private async Task GoToAllFoodsPage(bool fromSearch = false)
        {
            var parameters = new Dictionary<string, object> {
                [nameof(AllFoodsViewModel.FromSearch)] = fromSearch
            };
            await Shell.Current.GoToAsync(nameof(AllFoodsPage), animate: true, parameters);
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
