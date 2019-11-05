using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IStatusDB
    {
        List<Status> GetStatus();
        Status GetStatusId(int idStatus);
        Status AddStatus(Status status);
        int UpdateStatus(Status status);
        int DeleteStatus(int id);

    }
}
