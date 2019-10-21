using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    class StatusDB
    {
        public IConfiguration Configuration { get; }
        public StatusDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
