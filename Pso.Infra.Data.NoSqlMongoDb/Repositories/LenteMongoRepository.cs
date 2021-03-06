﻿using Pso.Domain.Entities;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Read;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Write;

namespace Pso.Infra.Data.NoSqlMongoDb.Repositories
{
    public class LenteMongoRepository : MongoRepository<Lente>, ILenteWriteMongoRepository, ILenteReadMongoRepository
    {
        public LenteMongoRepository(MongoDataContext context) : base(context)
        {
        }
    }
}
