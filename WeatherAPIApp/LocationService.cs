using System.Globalization;
using System.Threading.Tasks;


namespace WeatherAPIApp.Services
{
    public class LocationService
    {
        public async Task<(string locationName, string locationCoordinates, string alert)> GetLocationAsync()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync() ??
                               await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.High));

                if (location != null)
                {
                    double roundedLatitude = Math.Round(location.Latitude, 2);
                    double roundedLongitude = Math.Round(location.Longitude, 2);

                    string locationName = await GetLocationNameAsync(roundedLatitude, roundedLongitude);
                    string locationCoordinates = $"{roundedLatitude}, {roundedLongitude}";

                    return (locationName, locationCoordinates, null);
                }
                else
                {
                    return ("Warszawa", string.Empty, "Nie można uzyskać lokalizacji");
                }
            }
            catch (FeatureNotSupportedException)
            {
                return ("Warszawa", string.Empty, "Lokalizacja nie jest wspierana na tym urządzeniu.");
            }
            catch (PermissionException)
            {
                return ("Warszawa", string.Empty, null); // Brak alertu, ale domyślna lokalizacja
            }
            catch (Exception)
            {
                return ("Warszawa", string.Empty, "Błąd podczas pobierania lokalizacji.");
            }
        }

        private static async Task<string> GetLocationNameAsync(double latitude, double longitude)
        {
            var culture = CultureInfo.InvariantCulture;
            return $"{latitude.ToString(culture)},{longitude.ToString(culture)}";
        }
    }
}

