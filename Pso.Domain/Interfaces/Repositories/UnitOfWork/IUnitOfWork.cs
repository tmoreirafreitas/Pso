using System;
using System.Threading.Tasks;

namespace Pso.Domain.Interfaces.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        Task<bool> CommitAsync();
    }
}
