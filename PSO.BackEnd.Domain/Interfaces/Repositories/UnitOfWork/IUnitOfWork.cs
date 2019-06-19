using System;

namespace PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
