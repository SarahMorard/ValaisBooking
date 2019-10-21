using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using DAL;

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

            var CityDB = new CitiesDB(Configuration);

            /*Console.WriteLine(" -- NEW CITY -- ");
            var newCity = CityDB.AddCity(new Cities { zip_code = 3976, name = "Sion"});
            Console.WriteLine($"ID: {newCity.idCities} Name: {newCity.name}");*/
            var cities = CityDB.GetCities();
            foreach (var city in cities)
            {
                Console.WriteLine(city.ToString());
            }
        }
    }
}
