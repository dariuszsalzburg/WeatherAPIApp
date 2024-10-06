using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WeatherAPI.Standard.Models;
using WeatherAPI.Standard;

namespace WeatherAPIApp.ViewModels
{
    public class PageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<string> locationNames;
        private ObservableCollection<ForecastJsonResponse> weatherForcastDays;
        private int currentIndex;
        private readonly string locationKey;


        public PageViewModel(string pageTypeKey) // Pass unique key for each page (Temp, Wind, etc.)
        {
            locationKey = pageTypeKey; // Save the unique key (like TempPageLocationKey)
            LoadLocations();
            WeatherForcastDays = new ObservableCollection<ForecastJsonResponse>(); // Initialize the collection

            Task.Run(async () =>
            {
                await GetFavoriteData();
            });

            SelectLocationCommand = new Command<ForecastJsonResponse>(async (ForecastJsonResponse param) =>
            {
                await Shell.Current.GoToAsync($"//weather?locationName={param.Location.Name}");
            });

            SearchLocationCommand = new Command<string>(async (string locationName) =>
            {
                if (!string.IsNullOrWhiteSpace(locationName))
                {
                    await SearchAndUpdateLocation(locationName);
                }
            });
        }

        public async Task GetFavoriteData()
        {
            WeatherAPIClient weatherAPIClient = new();
            WeatherForcastDays.Clear();

            foreach (string locationName in locationNames)
            {
                var forecastWeather = await weatherAPIClient.APIs.GetForecastWeatherAsync(locationName, 10); // Fetch forecast data

                if (forecastWeather != null)
                {
                    WeatherForcastDays.Add(forecastWeather); // Add forecast data for each location
                }
            }
        }

        public async Task SearchAndUpdateLocation(string newLocationName)
        {
            try
            {
                WeatherAPIClient weatherAPIClient = new();
                var forecastWeather = await weatherAPIClient.APIs.GetForecastWeatherAsync(newLocationName, 5); // Fetch forecast data

                if (forecastWeather != null)
                {
                    bool locationExists = locationNames.Contains(newLocationName);
                    if (!locationExists)
                    {
                        if (currentIndex >= locationNames.Count)
                        {
                            locationNames.Add(newLocationName);
                        }
                        else
                        {
                            locationNames[currentIndex] = newLocationName;
                        }

                        currentIndex = (currentIndex + 1) % locationNames.Count;

                        SaveLocations();
                        WeatherForcastDays.Clear();
                        await GetFavoriteData();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching weather data: {ex.Message}");
            }
        }

        public void LoadLocations()
        {
            var savedLocations = Preferences.Get(locationKey, null); // Use passed key instead of hardcoded one
            if (savedLocations != null)
            {
                locationNames = new ObservableCollection<string>(JsonConvert.DeserializeObject<string[]>(savedLocations));
            }
            else
            {
                locationNames = new ObservableCollection<string> { "Warsaw", "London", "Paris", "Washington" };
            }
        }

        public void SaveLocations()
        {
            var json = JsonConvert.SerializeObject(locationNames.ToArray());
            Preferences.Set(locationKey, json); // Use passed key instead of hardcoded one
        }

        public ObservableCollection<Hour> WeatherForecastHours { get; set; }
        public ObservableCollection<ForecastJsonResponse> WeatherForcastDays
        {
            get { return weatherForcastDays; }
            set { weatherForcastDays = value; OnPropertyChanged(); }
        }

        public ICommand SelectLocationCommand { get; set; }
        public ICommand SearchLocationCommand { get; set; }
    }
}
