using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodMAUI.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public CartViewModel()
        {
        
        }
        public event EventHandler<Food> CartItemRemoved;
        public event EventHandler<Food> CartItemUpdated;
        public event EventHandler CartCleared;
        public ObservableCollection<Food> Items { get; set; } = new();

        [ObservableProperty]
        private double _totalAmount;

        private void RecalculateTotalAmount() => TotalAmount = Items.Sum(i => i.Amount);

        [RelayCommand]
        private void UpdateCartItem(Food food)
        {
            var item = Items.FirstOrDefault(i => i.Name == food.Name);
            if(item is not null)
            {
                item.CartQuantity = food.CartQuantity;
            }
            else
            {
                Items.Add(food.Clone());
            }
            RecalculateTotalAmount();
        }
        [RelayCommand]
        private async void RemoveCartItem(string name)
        {
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item is not null)
            {
                Items.Remove(item);
                RecalculateTotalAmount();

                CartItemRemoved?.Invoke(this, item);

                var snackbarOptions = new SnackbarOptions
                {
                    CornerRadius = 10,
                    BackgroundColor = Colors.PaleGoldenrod
                };
                var snackbar = Snackbar.Make($"'{item.Name}' removed from cart",
                    () =>
                    {
                        Items.Add(item);
                        RecalculateTotalAmount();
                        CartItemUpdated?.Invoke(this, item);
                    },"Undo",TimeSpan.FromSeconds(5), snackbarOptions);

                await snackbar.Show();
            }
        }
        [RelayCommand]
        private async Task ClearCart()
        {
            if (await Shell.Current.DisplayAlert("Confirm Clear Cart?", "Do you really want clear the cart items?", "Yes", "No"))
            {
                Items.Clear();
                RecalculateTotalAmount();
                CartCleared?.Invoke(this, EventArgs.Empty);

                await Toast.Make("Cart Cleared", ToastDuration.Short).Show();
            }      
        }

        [RelayCommand]
        private async Task PlaceOrder()
        {
            Items.Clear();
            CartCleared?.Invoke(this, EventArgs.Empty);
            RecalculateTotalAmount();
            await Shell.Current.GoToAsync(nameof(CheckoutPage), animate: true);
        }
    }
}
