﻿using Microsoft.EntityFrameworkCore;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Relational.Read;
using PSO.BackEnd.Domain.Interfaces.Repositories.Relational.Write;

namespace Pso.BackEnd.Infra.Data.EFCore.Repositories
{
    public class OculosRelationalRepository : Repository<Oculos>, IOculosWriteRelationalRepository, IOculosReadRelationalRepository
    {
        public OculosRelationalRepository(DbContext context) : base(context)
        {
        }
    }
}
