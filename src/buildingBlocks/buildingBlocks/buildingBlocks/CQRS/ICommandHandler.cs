using MediatR;
namespace buildingBlocks.CQRS;

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand<Unit>
{
    
}

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
where TCommand : ICommand<TResponse>
where TResponse : notnull
{
    
}