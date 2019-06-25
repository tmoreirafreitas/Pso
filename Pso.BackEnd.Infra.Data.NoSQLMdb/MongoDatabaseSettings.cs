using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pso.BackEnd.Infra.Data.NoSQLMdb
{
    public class PsoDbMongoDatabaseSettings : IPsoDbMongoDatabaseSettings
    {
        public string ConnectionString { get ; set; }
        public string DatabaseName { get; set; }
    }
}
