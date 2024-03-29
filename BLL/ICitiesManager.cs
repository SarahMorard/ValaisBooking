﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface ICitiesManager 
    {
        ICitiesManager CitiesDB { get; }
        List<Cities> GetCities();
        Cities GetCityId(int id);
        Cities AddCity(Cities city);
        int UpdateCities(Cities city);
        int DeleteCity(int IdCity);
    }
}
