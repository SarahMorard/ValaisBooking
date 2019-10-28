using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface ICitiesDB
    {
        List<Cities> GetCities();
        Cities GetCityId(int idCities);
        Cities AddCity(Cities city);
        int UpdateCity(Cities cities);
        int DeleteCity(int id);
    }
}
