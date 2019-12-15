using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface ILoginManager
    {
        ILoginManager LoginDB { get; }
        List<Login> GetLogins();
        Login GetLoginId(int id);
        Login AddLogin(Login login);
        int UpdateLogin(Login login);
        int DeleteLogin(int IdLogin);
        Login IsUserValid(string login, string password);
        Login GetLoginByFK(int fk);

    }
}
