using System;
using System.Threading.Tasks;

namespace PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        Task<bool> CommitAsync();
    }
}
