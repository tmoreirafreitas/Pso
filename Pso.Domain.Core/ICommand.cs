using MediatR;

namespace Pso.Domain.Core
{
    public interface ICommand : IRequest
    {
        
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}