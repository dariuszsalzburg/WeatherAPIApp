using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Web;
using System.Windows.Input;
using WeatherAPI.Standard;
using WeatherAPI.Standard.Models;
using WeatherAPIApp.Models;
using WeatherAPIApp.Services;

namespace WeatherAPIApp.ViewModels
{
    public class WeatherPageViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly LocationService _locationService;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public WeatherPageViewModel()
        {
            _locationService = new LocationService(); // Inicjalizacja nowej klasy LocationService
            // Inicjalizacja PreferenceManager
            PreferenceManager = new PreferenceManager();

            // Inicjalizacja lokalizacji i pobieranie danych pogodowych
            Task.Run(async () =>
            {
                InitializeLocation();
                await GetWeatherData();
            });


            SearchLocationCommand = new Command(async () =>
            {
                if (!string.IsNullOrWhiteSpace(UserInputLocation))
                {
                    LocationName = UserInputLocation;
                    await GetWeatherData();
                    UserInputLocation = string.Empty; // Clear the input after search
                }
            });

            RefreshCommand = new Command(() =>
            {
                Task.Run(() =>
                {
                    GetWeatherData().GetAwaiter().OnCompleted(() =>
                    {
                        IsRefreshing = false;
                    });
                });
            });
        }
        
        // Inicjalizacja lokalizacji

        private async Task InitializeLocation()
        {
            var (locationName, locationCoordinates, alert) = await _locationService.GetLocationAsync();

            LocationName = locationName;
            LocationCoordinates = locationCoordinates;
            Alert = alert;
        }
        // Pobieranie danych pogodowych
        public async Task GetWeatherData()
        {
            try
            {
                WeatherAPIClient client = new();
                var forecastWeather = await client.APIs.GetForecastWeatherAsync(LocationName, 5);

                LocationName = forecastWeather.Location.Name;
                CurrentWeather = forecastWeather.Current;

                var weatherForecastDaysClone = new List<Forecastday>(forecastWeather.Forecast.Forecastday);
                WeatherForecastDays = new ObservableCollection<Forecastday>(weatherForecastDaysClone);

                // Aktualizacja pogody w PreferenceManager
                PreferenceManager.CurrentWeather = forecastWeather.Current;

                var weatherForecastHours48 = new List<Hour>(forecastWeather.Forecast.Forecastday[0].Hours);
                weatherForecastHours48.AddRange(new List<Hour>(forecastWeather.Forecast.Forecastday[1].Hours));

                var nextHourIndex = weatherForecastHours48.IndexOf(weatherForecastHours48.Where(x => x.Time.CompareTo(forecastWeather.Location.Localtime) >= 0).FirstOrDefault());
                weatherForecastHours48.ForEach(x => x.Time = x.Time[11..]);

                WeatherForecastHours = new ObservableCollection<Hour>(weatherForecastHours48.GetRange(nextHourIndex, 24));
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Dispatch(() =>
                {
                    Application.Current.MainPage.DisplayAlert("WeatherApp", ex.Message, "OK");
                });
            }
        }

        // Implementacja IQueryAttributable dla obsługi nawigacji
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Count == 0) return;
            LocationName = HttpUtility.UrlDecode(query["locationName"].ToString());

            Task.Run(() =>
            {
                GetWeatherData().GetAwaiter().OnCompleted(() =>
                {
                    IsRefreshing = false;
                });
            });
        }

        public async void RefreshWeatherData()
        {
            InitializeLocation();
            await GetWeatherData();
        }

        // Metoda pomocnicza do uzyskania nazwy lokalizacji
        private static async Task<string> GetLocationNameAsync(double latitude, double longitude)
        {
            var culture = CultureInfo.InvariantCulture;
            return $"{latitude.ToString(culture)},{longitude.ToString(culture)}";
        }

        // Właściwości ViewModelu
        private string locationName;
        private Current currentWeather;
        private ObservableCollection<Hour> weatherForecastHours;
        private ObservableCollection<Forecastday> weatherForecastDays;
        private bool isRefreshing;
        private string locationCoordinates;
        private string alert;

        public string FullLocationInfo => $"{LocationName} ({LocationCoordinates})";

        public string LocationName
        {
            get { return locationName; }
            set
            {
                locationName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullLocationInfo));
            }
        }

        public string LocationCoordinates
        {
            get { return locationCoordinates; }
            set
            {
                locationCoordinates = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullLocationInfo));
            }
        }

        public string Alert
        {
            get { return alert; }
            set
            {
                alert = value;
                OnPropertyChanged();
            }
        }

        public Current CurrentWeather
        {
            get { return currentWeather; }
            set
            {
                currentWeather = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Hour> WeatherForecastHours
        {
            get { return weatherForecastHours; }
            set
            {
                weatherForecastHours = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Forecastday> WeatherForecastDays
        {
            get { return weatherForecastDays; }
            set
            {
                weatherForecastDays = value;
                OnPropertyChanged();
            }
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }
        private string userInputLocation;

        public string UserInputLocation
        {
            get { return userInputLocation; }
            set
            {
                userInputLocation = value;
                OnPropertyChanged();
            }
        }
        public ICommand SearchLocationCommand { get; set; }

        // Właściwość do obsługi zarządzania preferencjami i rekomendacjami
        public PreferenceManager PreferenceManager { get; set; }

        // Komendy
        public ICommand RefreshCommand { get; set; }
    }
}
