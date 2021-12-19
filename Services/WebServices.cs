using FullStackManagementMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static FullStackManagementMVC.Models.Photos;

namespace FullStackManagementMVC.Services
{
    public class WebServices
    {
        //Services
        //add System.Net.Http collection
        //add services httpClient

        private readonly HttpClient httpClient;
        //Dependency Injection
        //The constructor creates the httpClient object inside the parameters
        public WebServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<WeatherData> GetData(string endPoint)
        {
            //Get request at endpoint and perform deserialization of JSON into an object
            //Add Newtonsoft.Json
            //Return null if first return fails

            try
            {
                return await httpClient.GetFromJsonAsync<WeatherData>(endPoint);
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("HTTP Request Error");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The content is not supported");
            }
            catch (JsonException)
            {
                Console.WriteLine("Bad JSON");
            }
            return null;
        }
        public async Task<Nasa> GetData2(string endPoint)
        {
            //Get request at endpoint and perform deserialization of JSON into an object
            //Add Newtonsoft.Json
            //Return null if first return fails
            try
            {
                return await httpClient.GetFromJsonAsync<Nasa>(endPoint);
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("HTTP Request Error");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The content is not supported");
            }
            catch (JsonException)
            {
                Console.WriteLine("Bad JSON");
            }
            return null;
        }
        public async Task<Yelp> GetData3(string endPoint)
        {
            //Get request at endpoint and perform deserialization of JSON into an object
            //Add Newtonsoft.Json
            //Return null if first return fails
            try
            {
                return await httpClient.GetFromJsonAsync<Yelp>(endPoint);
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("HTTP Request Error");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The content is not supported");
            }
            catch (JsonException)
            {
                Console.WriteLine("Bad JSON");
            }
            return null;
        }        
        public async Task<News> GetData4(string endPoint)
        {
            //Get request at endpoint and perform deserialization of JSON into an object
            //Add Newtonsoft.Json
            //Return null if first return fails
            try
            {
                return await httpClient.GetFromJsonAsync<News>(endPoint);
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("HTTP Request Error");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The content is not supported");
            }
            catch (JsonException)
            {
                Console.WriteLine("Bad JSON");
            }
            return null;
        }        
        public async Task<List<Class1>> GetData5(string endPoint)
        {
            //Get request at endpoint and perform deserialization of JSON into an object
            //Add Newtonsoft.Json
            //Return null if first return fails
            try
            {
                return await httpClient.GetFromJsonAsync<List<Class1>>(endPoint);
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("HTTP Request Error");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The content is not supported");
            }
            catch (JsonException)
            {
                Console.WriteLine("Bad JSON");
            }
            return null;
        }        
        //Crypto
        public async Task<Stocks> GetData6(string endPoint)
        {
            //Get request at endpoint and perform deserialization of JSON into an object
            //Add Newtonsoft.Json
            //Return null if first return fails
            try
            {
                return await httpClient.GetFromJsonAsync<Stocks>(endPoint);
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("HTTP Request Error");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The content is not supported");
            }
            catch (JsonException)
            {
                Console.WriteLine("Bad JSON");
            }
            return null;
        }        
        public async Task<Stocks> GetData7(string endPoint)
        {
            //Get request at endpoint and perform deserialization of JSON into an object
            //Add Newtonsoft.Json
            //Return null if first return fails
            try
            {
                return await httpClient.GetFromJsonAsync<Stocks>(endPoint);
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("HTTP Request Error");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The content is not supported");
            }
            catch (JsonException)
            {
                Console.WriteLine("Bad JSON");
            }
            return null;
        }
    }
}
