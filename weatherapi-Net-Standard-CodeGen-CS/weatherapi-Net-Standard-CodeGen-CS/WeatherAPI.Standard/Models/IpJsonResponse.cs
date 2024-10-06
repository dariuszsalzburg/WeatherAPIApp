/*
 * WeatherAPI.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WeatherAPI.Standard;
using WeatherAPI.Standard.Utilities;


namespace WeatherAPI.Standard.Models
{
    public class IpJsonResponse : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string ip;
        private string type;
        private string continentCode;
        private string continentName;
        private string countryCode;
        private string countryName;
        private bool? isEu;
        private int? geonameId;
        private string city;
        private string region;
        private double? lat;
        private double? lon;
        private string tzId;
        private int? localtimeEpoch;
        private string localtime;

        /// <summary>
        /// IP address
        /// </summary>
        [JsonProperty("ip")]
        public string Ip 
        { 
            get 
            {
                return this.ip; 
            } 
            set 
            {
                this.ip = value;
                OnPropertyChanged("Ip");
            }
        }

        /// <summary>
        /// ipv4 or ipv6
        /// </summary>
        [JsonProperty("type")]
        public string Type 
        { 
            get 
            {
                return this.type; 
            } 
            set 
            {
                this.type = value;
                OnPropertyChanged("Type");
            }
        }

        /// <summary>
        /// Continent code
        /// </summary>
        [JsonProperty("continent_code")]
        public string ContinentCode 
        { 
            get 
            {
                return this.continentCode; 
            } 
            set 
            {
                this.continentCode = value;
                OnPropertyChanged("ContinentCode");
            }
        }

        /// <summary>
        /// Continent name
        /// </summary>
        [JsonProperty("continent_name")]
        public string ContinentName 
        { 
            get 
            {
                return this.continentName; 
            } 
            set 
            {
                this.continentName = value;
                OnPropertyChanged("ContinentName");
            }
        }

        /// <summary>
        /// Country code
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode 
        { 
            get 
            {
                return this.countryCode; 
            } 
            set 
            {
                this.countryCode = value;
                OnPropertyChanged("CountryCode");
            }
        }

        /// <summary>
        /// Name of country
        /// </summary>
        [JsonProperty("country_name")]
        public string CountryName 
        { 
            get 
            {
                return this.countryName; 
            } 
            set 
            {
                this.countryName = value;
                OnPropertyChanged("CountryName");
            }
        }

        /// <summary>
        /// true or false
        /// </summary>
        [JsonProperty("is_eu")]
        public bool? IsEu 
        { 
            get 
            {
                return this.isEu; 
            } 
            set 
            {
                this.isEu = value;
                OnPropertyChanged("IsEu");
            }
        }

        /// <summary>
        /// Geoname ID
        /// </summary>
        [JsonProperty("geoname_id")]
        public int? GeonameId 
        { 
            get 
            {
                return this.geonameId; 
            } 
            set 
            {
                this.geonameId = value;
                OnPropertyChanged("GeonameId");
            }
        }

        /// <summary>
        /// City name
        /// </summary>
        [JsonProperty("city")]
        public string City 
        { 
            get 
            {
                return this.city; 
            } 
            set 
            {
                this.city = value;
                OnPropertyChanged("City");
            }
        }

        /// <summary>
        /// Region name
        /// </summary>
        [JsonProperty("region")]
        public string Region 
        { 
            get 
            {
                return this.region; 
            } 
            set 
            {
                this.region = value;
                OnPropertyChanged("Region");
            }
        }

        /// <summary>
        /// Latitude in decimal degree
        /// </summary>
        [JsonProperty("lat")]
        public double? Lat 
        { 
            get 
            {
                return this.lat; 
            } 
            set 
            {
                this.lat = value;
                OnPropertyChanged("Lat");
            }
        }

        /// <summary>
        /// Longitude in decimal degree
        /// </summary>
        [JsonProperty("lon")]
        public double? Lon 
        { 
            get 
            {
                return this.lon; 
            } 
            set 
            {
                this.lon = value;
                OnPropertyChanged("Lon");
            }
        }

        /// <summary>
        /// Time zone
        /// </summary>
        [JsonProperty("tz_id")]
        public string TzId 
        { 
            get 
            {
                return this.tzId; 
            } 
            set 
            {
                this.tzId = value;
                OnPropertyChanged("TzId");
            }
        }

        /// <summary>
        /// Local time as epoch
        /// </summary>
        [JsonProperty("localtime_epoch")]
        public int? LocaltimeEpoch 
        { 
            get 
            {
                return this.localtimeEpoch; 
            } 
            set 
            {
                this.localtimeEpoch = value;
                OnPropertyChanged("LocaltimeEpoch");
            }
        }

        /// <summary>
        /// Date and time
        /// </summary>
        [JsonProperty("localtime")]
        public string Localtime 
        { 
            get 
            {
                return this.localtime; 
            } 
            set 
            {
                this.localtime = value;
                OnPropertyChanged("Localtime");
            }
        }
    }
} 