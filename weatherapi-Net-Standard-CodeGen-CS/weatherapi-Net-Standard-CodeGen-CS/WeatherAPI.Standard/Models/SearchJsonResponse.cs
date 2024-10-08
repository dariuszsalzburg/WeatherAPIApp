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
    public class SearchJsonResponse : BaseModel 
    {
        // These fields hold the values for the public properties.
        private int? id;
        private string name;
        private string region;
        private string country;
        private double? lat;
        private double? lon;
        private string url;

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("id")]
        public int? Id 
        { 
            get 
            {
                return this.id; 
            } 
            set 
            {
                this.id = value;
                OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Local area name.
        /// </summary>
        [JsonProperty("name")]
        public string Name 
        { 
            get 
            {
                return this.name; 
            } 
            set 
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Local area region.
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
        /// Country
        /// </summary>
        [JsonProperty("country")]
        public string Country 
        { 
            get 
            {
                return this.country; 
            } 
            set 
            {
                this.country = value;
                OnPropertyChanged("Country");
            }
        }

        /// <summary>
        /// Area latitude
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
        /// Area longitude
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
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("url")]
        public string Url 
        { 
            get 
            {
                return this.url; 
            } 
            set 
            {
                this.url = value;
                OnPropertyChanged("Url");
            }
        }
    }
} 