﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ValaisRestaurants
{
    class LoginDB
    {
        public IConfiguration Configuration { get; }
        public LoginDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
