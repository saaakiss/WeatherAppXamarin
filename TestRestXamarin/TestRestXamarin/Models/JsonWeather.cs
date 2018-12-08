using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRestXamarin.Models
{
    class JsonWeather
    {
        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class City
        {
            public int id { get; set; }
            public string name { get; set; }
            public Coord coord { get; set; }
            public string country { get; set; }
            public int population { get; set; }
        }

        public class Temp
        {
            public double day { get; set; }

            private string _min;
            public string min
            {
                get
                {
                    return "Min: " + _min + "℃";
                }

                set
                {
                    _min = value;
                }
            }

            private string _max;
            public string max
            {
                get
                {
                    return "- Max: " + _max + "℃";
                }

                set
                {
                    _max = value;
                }
            }

            public double night { get; set; }
            public double eve { get; set; }
            public double morn { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class ListJs
        {
            public string normDate { get; set; }
            public int dt { get; set; }
            public Temp temp { get; set; }
            public double pressure { get; set; }

            private string _humidity;
            public string humidity
            {
                get
                {
                    return _humidity + "%";
                }

                set
                {
                    _humidity = value;
                }
            }

            public List<Weather> weather { get; set; }

            private string _speed;
            public string speed
            {
                get
                {
                    return _speed + " m/s";
                }

                set
                {
                    _speed = value;
                }
            }
            public int deg { get; set; }
            public int clouds { get; set; }
            public double? rain { get; set; }
        }

        public class RootObject
        {
            public City city { get; set; }
            public string cod { get; set; }
            public double message { get; set; }
            public int cnt { get; set; }
            public List<ListJs> list { get; set; }
        }

    }
}
