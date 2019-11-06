using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IStaffDB
    {
        List<Staff> GetStaff();
        Staff GetStaffId(int idStaff);
        Staff AddStaff(Staff staff);
        int UpdateStaff(Staff staff);
        int DeleteStaff(int id);
    }
}
