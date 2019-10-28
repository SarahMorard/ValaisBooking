using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    class LoginManager
    {
        public ILoginDB LoginDB{ get; }

        public LoginManager(IConfiguration configuration)
        {
            LoginDB = new LoginDB(configuration);
        }

        public List<Login> GetHotels()
        {
            return LoginDB.GetLogin();
        }

        public Login GetHotelId(int id)
        {
            return LoginDB.GetLoginId(id);
        }

        public Login AddHotel(Login hotel)
        {
            return LoginDB.AddLogin(hotel);
        }

        public int UpdateHotel(Login login)
        {
            return LoginDB.UpdateLogin(login);
        }

        public int DeleteHotel(int IdLogin)
        {
            return LoginDB.DeleteLogin(IdLogin);
        }
    }
}
