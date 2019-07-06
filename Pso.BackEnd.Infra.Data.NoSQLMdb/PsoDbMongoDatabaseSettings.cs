﻿using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb
{
    public class PsoDbMongoDatabaseSettings
    {
        public string ConnectionString { get ; set; }
        public string DatabaseName { get; set; }
        public bool IsSSL { get; set; }
    }
}