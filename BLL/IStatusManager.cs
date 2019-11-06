using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IStatusManager
    {
        IStatusManager StatusDB { get; }
        List<Status> GetStatus();
        Status GetStatusId(int id);
        Status AddStatus(Status status);
        int UpdateStatus(Status status);
        int DeleteStatus(int IdStatus);
    }
}
