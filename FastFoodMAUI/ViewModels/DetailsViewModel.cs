using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodMAUI.ViewModels
{
    [QueryProperty(nameof(Food), nameof(Food))]
    public partial class DetailsViewModel : ObservableObject, IDisposable
    {
        private readonly CartViewModel _cartViewModel;
        public DetailsViewModel(CartViewModel cartViewModel)
        {
            _cartViewModel = cartViewModel;

            _cartViewModel.CartCleared += OnCartCleared;
            _cartViewModel.CartItemRemoved += OnCartItemRemoved;
            _cartViewModel.CartItemUpdated += OnCartItemUpdated;
        }

        private void OnCartCleared(object? _, EventArgs e) => Food.CartQuantity = 0;

        private void OnCartItemRemoved(object? _, Food f) => OnCartItemChanged(f, 0);

        private void OnCartItemUpdated(object? _, Food f) => OnCartItemChanged(f, f.CartQuantity);

        private void OnCartItemChanged(Food f, int quantity)
        {
            if(f.Name == Food.Name)
            {
                Food.CartQuantity = quantity;
            }
        }

        [ObservableProperty]
        private Food _food;

        [RelayCommand]
        private void AddToCart()
        {
            Food.CartQuantity++;
            _cartViewModel.UpdateCartItemCommand.Execute(Food);
        }

        [RelayCommand]
        private void RemoveFromCart()
        {
            if (Food.CartQuantity > 0)
            {
                Food.CartQuantity--;
                _cartViewModel.UpdateCartItemCommand.Execute(Food);
            }
        }

        [RelayCommand]
        private async Task ViewCart()
        {
            if (Food.CartQuantity > 0)
            {
                await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
            }
            else
            {
                await Toast.Make("Please select the quantity using the plus (+) button", ToastDuration.Short).Show();
            }
        }

        public void Dispose()
        {
            _cartViewModel.CartCleared -= OnCartCleared;
            _cartViewModel.CartItemRemoved -= OnCartItemRemoved;
            _cartViewModel.CartItemUpdated -= OnCartItemUpdated;
        }
    }
}
