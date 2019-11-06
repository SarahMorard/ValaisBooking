using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class StaffManager
    {
        public IStaffDB StaffDB { get; }

        public StaffManager(IConfiguration configuration)
        {
            StaffDB = new StaffDB(configuration);
        }

        public List<Staff> GetStaff()
        {
            return StaffDB.GetStaff();
        }

        public Staff GetStaffId(int id)
        {
            return StaffDB.GetStaffId(id);
        }

        public Staff AddStaff(Staff staff)
        {
            return StaffDB.AddStaff(staff);
        }

        public int UpdateStaff(Staff staff)
        {
            return StaffDB.UpdateStaff(staff);
        }

        public int DeleteStaff(int IdStaff)
        {
            return StaffDB.DeleteStaff(IdStaff);
        }
    }
}
