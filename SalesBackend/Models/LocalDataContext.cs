﻿using SalesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesBackend.Models
{
     public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<SalesCannon.Models.Finca> Fincas { get; set; }
    }
}