using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;

namespace FastFoodMAUI.Pages;

public partial class DetailPage : ContentPage
{
	private readonly DetailsViewModel _detailsViewModel;
	public DetailPage(DetailsViewModel detailsViewModel)
	{
		_detailsViewModel = detailsViewModel;
		InitializeComponent();
		BindingContext = _detailsViewModel;
	}

    async void ImageButton_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("..", animate: true);
    }

    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        base.OnNavigatingFrom(args);
		Behaviors.Add(new StatusBarBehavior
		{
			StatusBarColor = Colors.DarkGoldenrod,
			StatusBarStyle = StatusBarStyle.LightContent
		});
    }
}