using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    class StatusManager
    {
        public IStatusDB StatusDB { get; }

        public StatusManager(IConfiguration configuration)
        {
            StatusDB = new StatusDB(configuration);
        }

        public List<Status> GetStatus()
        {
            return StatusDB.GetStatus();
        }

        public Status GetStatusId(int id)
        {
            return StatusDB.GetStatusId(id);
        }

        public Status AddStatus(Status status)
        {
            return StatusDB.AddHotel(status);
        }

        public int UpdateStatus(Status status)
        {
            return StatusDB.UpdateStatus(status);
        }

        public int DeleteStatus(int IdStatus)
        {
            return StatusDB.DeleteStatus(IdStatus);
        }
    }
}
