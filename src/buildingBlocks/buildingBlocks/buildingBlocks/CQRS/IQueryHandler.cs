using MediatR;
namespace buildingBlocks.CQRS;

public interface IQueryHandler<in TCommand>
    where TCommand : ICommand<Unit>
{
    
}

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : notnull
{
    
}