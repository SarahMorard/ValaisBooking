using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using DAL;
using BLL;
using DTO;

namespace ValaisRestaurants
{
    class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
           .Build();
        static void Main(string[] args)
        {
            var CitiesManager = new CitiesManager(Configuration);

            var cities = CitiesManager.GetCities();


            foreach (var city in cities)
            {
                Console.WriteLine(city.ToString());
            }
        }
    }
}
