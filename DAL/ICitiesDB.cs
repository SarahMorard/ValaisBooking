using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface ICitiesDB
    {
        List<Cities> GetCities();

    }
}
