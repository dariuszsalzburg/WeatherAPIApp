using System.ComponentModel;
using System.Runtime.CompilerServices;
using WeatherAPI.Standard.Models;

namespace WeatherAPIApp.Models
{
    public class PreferenceManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string selectedPreference;
        public string SelectedPreference
        {
            get { return selectedPreference; }
            set
            {
                selectedPreference = value;
                OnPropertyChanged();
                GenerateRecommendationBasedOnPreference(); // Generate recommendation when preference is updated
            }
        }

        public List<string> Preferences { get; set; } = new List<string>
        {
            "Indoor Activities",
            "Outdoor Activities",
            "Travel",
            "Relaxation",
            "Exercise"
        };

        private string recommendation;
        public string Recommendation
        {
            get { return recommendation; }
            private set { recommendation = value; OnPropertyChanged(); }
        }

        private Current currentWeather;

        public Current CurrentWeather
        {
            get { return currentWeather; }
            set
            {
                currentWeather = value;
                OnPropertyChanged();
                GenerateRecommendationBasedOnPreference();
            }
        }

        public void GenerateRecommendationBasedOnPreference()
        {
            if (CurrentWeather == null) return;

            double tempC = (double)currentWeather.TempC;
            string condition = currentWeather.Condition.Text.ToLower();

            if (SelectedPreference == "Indoor Activities")
            {
                if (condition.Contains("rain") || condition.Contains("snow"))
                {
                    Recommendation = "It looks like a great day to stay indoors and enjoy a book or movie.";
                }
                else
                {
                    Recommendation = "Perfect weather for indoor activities, but you can also enjoy the outdoors!";
                }
            }
            else if (SelectedPreference == "Outdoor Activities")
            {
                if (tempC > 20 && !condition.Contains("rain"))
                {
                    Recommendation = "Great weather for outdoor activities! Go for a walk or have a picnic.";
                }
                else
                {
                    Recommendation = "It might be better to stay indoors today.";
                }
            }
            else if (SelectedPreference == "Travel")
            {
                if (tempC > 15)
                {
                    Recommendation = "Perfect weather for a day trip! Enjoy your travel.";
                }
                else
                {
                    Recommendation = "Maybe consider a shorter trip due to the weather conditions.";
                }
            }
            else if (SelectedPreference == "Relaxation")
            {
                Recommendation = "No matter the weather, it's always a good time to relax!";
            }
            else if (SelectedPreference == "Exercise")
            {
                if (tempC > 15 && tempC < 30)
                {
                    Recommendation = "Great weather for outdoor exercises! Time to go for a run or bike ride.";
                }
                else
                {
                    Recommendation = "Consider indoor exercises today due to the weather.";
                }
            }
            else
            {
                Recommendation = "Enjoy your day!";
            }
        }
    }
}
