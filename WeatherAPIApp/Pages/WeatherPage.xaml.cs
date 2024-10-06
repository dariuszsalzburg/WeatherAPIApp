using WeatherAPIApp.ViewModels;
using static WeatherAPIApp.ViewModels.WeatherPageViewModel;

namespace WeatherAppClone.Pages;

public partial class WeatherPage : ContentPage
{
	public WeatherPage()
	{
       InitializeComponent();
        BindingContext = new WeatherPageViewModel();

    }
    private async void OnLocationEntryCompleted(object sender, EventArgs e)
    {
        var viewModel = BindingContext as WeatherPageViewModel;
        if (viewModel != null)
        {
            if (!string.IsNullOrWhiteSpace(viewModel.UserInputLocation))
            {
                viewModel.LocationName = viewModel.UserInputLocation;
                await viewModel.GetWeatherData();
                viewModel.UserInputLocation = string.Empty; // Clear the input after search
                viewModel.LocationCoordinates = string.Empty;
            }
        }
    }
    public Task ShowAlert(string title, string message, string cancel)
    {
        return DisplayAlert(title, message, cancel);
    }
}