using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class LoginManager : ILoginManager
    {

        public ILoginDB LoginDB { get; }

        ILoginManager ILoginManager.LoginDB => throw new NotImplementedException();

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

        public List<Login> GetLogin()
        {
            throw new NotImplementedException();
        }

        public Login IsUserValid(string login, string password)
        {
             
            return LoginDB.IsUserValid(login, password);
        }
    }
}