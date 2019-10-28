using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class CitiesManager
    {
        public CitiesDB CitiesDB { get; }
        public CitiesManager (IConfiguration configuration);

        public List<Cities> GetCities()
        {
            return CitiesDB.GetCities();
        }
        public Cities GetHotelId(int id)
        {
            return CitiesDB.GetCityId(id);
        }

        public Cities AddHotel(Cities city)
        {
            return CitiesDB.AddCity(city);
        }

        public int UpdateCities(Cities city)
        {
            return CitiesDB.UpdateCity(city);
        }

        public int DeleteCity(int IdCity)
        {
            return CitiesDB.DeleteHotel(IdCity);
        }

    }
}
