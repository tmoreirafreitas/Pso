using System;
using System.Collections.Generic;
using System.Text;

namespace PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb
{
    public interface IMongoDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
