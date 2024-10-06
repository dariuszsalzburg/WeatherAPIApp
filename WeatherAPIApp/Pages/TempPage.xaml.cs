using WeatherAPIApp.ViewModels;

namespace WeatherAppClone.Pages;

public partial class TempPage : ContentPage
{
	public TempPage()
	{
		InitializeComponent();
        BindingContext = new PageViewModel("key3");
    }
}