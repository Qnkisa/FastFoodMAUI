using CommunityToolkit.Maui;
using FastFoodMAUI.Pages;
using FastFoodMAUI.Services;
using FastFoodMAUI.ViewModels;
using Microsoft.Extensions.Logging;

namespace FastFoodMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).UseMauiCommunityToolkit();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            AddFoodServices(builder.Services);
            return builder.Build();
        }

        private static IServiceCollection AddFoodServices(IServiceCollection services)
        {
            services.AddSingleton<FoodService>();

            services.AddSingleton<HomePage>().AddSingleton<HomeViewModel>();

            services.AddTransientWithShellRoute<AllFoodsPage, AllFoodsViewModel>(nameof(AllFoodsPage));

            services.AddTransientWithShellRoute<DetailPage, DetailsViewModel>(nameof(DetailPage));

            services.AddSingleton<CartViewModel>();
            services.AddTransient<CartPage>();

            return services;
        }
    }
}
