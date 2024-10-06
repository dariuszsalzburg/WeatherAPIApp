using WeatherAPIApp.ViewModels;
using WeatherAppClone;
using WeatherAppClone.Pages;

namespace WeatherAPIApp
{
    public partial class App : Application
    {

        public App()
        {

            InitializeComponent();
            MainPage = new MainPage();

        }

       
    }
}
