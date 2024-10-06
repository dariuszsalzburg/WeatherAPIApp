using WeatherAPIApp.ViewModels;

namespace WeatherAppClone.Pages;

public partial class WindPage : ContentPage
{
	public WindPage()
	{
		InitializeComponent();
        BindingContext = new PageViewModel("key4");
    }
}