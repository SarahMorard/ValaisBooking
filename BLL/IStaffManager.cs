using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class IStaffManager
    {
        IStaffManager StaffDB { get; }
        List<Staff> GetStafft();
        Staff GetStaffId(int id);
        Staff AddStaff(Staff staff);
        int UpdateStaff(Staff staff);
        int DeleteStaff(int IdStaff);
    }
}
