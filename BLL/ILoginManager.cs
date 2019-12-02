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
        List<Login> GetLogin();
        Login GetLoginId(int id);
        Login AddLogin(Login login);
        int UpdateLogin(Login login);
        int DeleteLogin(int IdLogin);
        bool IsUserValid(Login l);
    }
}
