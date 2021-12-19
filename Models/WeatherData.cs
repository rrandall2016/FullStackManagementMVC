using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackManagementMVC.Models
{
    public class WeatherData
    {


        //Provides an object representation of a-
        //- uniform resource identifier (URI) and easy access to the parts of the URI.


            public string message { get; set; }
            public string cod { get; set; }
            public int count { get; set; }
            public List[] list { get; set; }
        

        public class List
        {
            public int id { get; set; }
            public string name { get; set; }
            public Coord coord { get; set; }
            public Main main { get; set; }
            public int dt { get; set; }
            public Wind wind { get; set; }
            public Sys sys { get; set; }
            public object rain { get; set; }
            public object snow { get; set; }
            public Clouds clouds { get; set; }
            public Weather[] weather { get; set; }
        }

        public class Coord
        {
            public float lat { get; set; }
            public float lon { get; set; }
        }

        public class Main
        {
            public float temp { get; set; }
            public float feels_like { get; set; }
            public float temp_min { get; set; }
            public float temp_max { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
        }

        public class Wind
        {
            public float speed { get; set; }
            public int deg { get; set; }
        }

        public class Sys
        {
            public string country { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }



    }
}
