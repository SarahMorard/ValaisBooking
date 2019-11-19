﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class StatusManager
    {
        public IStatusDB StatusDB { get; }
        public IDishesDB DishesDB { get; }

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
            return StatusDB.AddStatus(status);
        }

        public int UpdateStatus(Status status)
        {
            return StatusDB.UpdateStatus(status);
        }

        public int DeleteStatus(int IdStatus)
        {
            DishesDB.DeleteDishFromFK(IdStatus);
            return StatusDB.DeleteStatus(IdStatus);
        }
    }
}
