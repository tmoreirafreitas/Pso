using MediatR;

namespace Pso.Domain.Core
{
    public interface ICommand : IRequest
    {
        public string Name { get; }
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
        public string Name { get; }
    }
}