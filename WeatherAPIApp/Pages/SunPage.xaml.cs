using WeatherAPIApp.ViewModels;

namespace WeatherAppClone.Pages;

public partial class SunPage : ContentPage
{
	public SunPage()
	{
		InitializeComponent();
        BindingContext = new PageViewModel("key2");
    }
}