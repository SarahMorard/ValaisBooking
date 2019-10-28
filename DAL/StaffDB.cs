using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class StaffDB
    {
        public IConfiguration Configuration { get; }
        public StaffDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
