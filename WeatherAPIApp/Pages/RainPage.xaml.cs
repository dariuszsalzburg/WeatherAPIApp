using WeatherAPIApp.ViewModels;

namespace WeatherAppClone.Pages;

public partial class RainPage : ContentPage
{
	public RainPage()
	{
        InitializeComponent();
		BindingContext = new PageViewModel("key1");
	}
}