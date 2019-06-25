using System;
using System.Collections.Generic;
using System.Text;

namespace PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb
{
    public interface IPsoDbMongoDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
