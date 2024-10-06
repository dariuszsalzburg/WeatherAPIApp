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
    public class Forecastday1 : BaseModel 
    {
        // These fields hold the values for the public properties.
        private string date;
        private int? dateEpoch;
        private Models.Day day;
        private Models.Astro astro;
        private List<Models.Hour> hour;

        /// <summary>
        /// Forecast date
        /// </summary>
        [JsonProperty("date")]
        public string Date 
        { 
            get 
            {
                return this.date; 
            } 
            set 
            {
                this.date = value;
                OnPropertyChanged("Date");
            }
        }

        /// <summary>
        /// Forecast date as unix time.
        /// </summary>
        [JsonProperty("date_epoch")]
        public int? DateEpoch 
        { 
            get 
            {
                return this.dateEpoch; 
            } 
            set 
            {
                this.dateEpoch = value;
                OnPropertyChanged("DateEpoch");
            }
        }

        /// <summary>
        /// See day element
        /// </summary>
        [JsonProperty("day")]
        public Models.Day Day 
        { 
            get 
            {
                return this.day; 
            } 
            set 
            {
                this.day = value;
                OnPropertyChanged("Day");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("astro")]
        public Models.Astro Astro 
        { 
            get 
            {
                return this.astro; 
            } 
            set 
            {
                this.astro = value;
                OnPropertyChanged("Astro");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("hour")]
        public List<Models.Hour> Hour 
        { 
            get 
            {
                return this.hour; 
            } 
            set 
            {
                this.hour = value;
                OnPropertyChanged("Hour");
            }
        }
    }
} 