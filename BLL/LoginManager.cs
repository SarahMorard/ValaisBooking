using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class LoginManager
    {
        public ILoginDB LoginDB{ get; }

        public LoginManager(IConfiguration configuration)
        {
            LoginDB = new LoginDB(configuration);
        }

        public List<Login> GetLogins()
        {
            return LoginDB.GetLogins();
        }

        public Login GetLoginId(int id)
        {
            return LoginDB.GetLoginId(id);
        }

        public Login AddLogin(Login login)
        {
            return LoginDB.AddLogin(login);
        }

        public int UpdateLogin(Login login)
        {
            return LoginDB.UpdateLogin(login);
        }

        public int DeleteLogin(int IdLogin)
        {
            return LoginDB.DeleteLogin(IdLogin);
        }
    }
}
