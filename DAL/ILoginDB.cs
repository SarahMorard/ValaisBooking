using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface ILoginDB
    {
        bool IsUserValid(Login l);
        List<Login> GetLogins();
        Login GetLoginId(int idLogin);
        Login AddLogin(Login login);
        int UpdateLogin(Login login);
        int DeleteLogin(int id);
    }
}
