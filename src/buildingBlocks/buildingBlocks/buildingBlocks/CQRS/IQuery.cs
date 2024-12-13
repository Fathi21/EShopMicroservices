using MediatR;
namespace buildingBlocks.CQRS;

public interface IQuery<out TResponse>: IRequest<TResponse>
    where TResponse: notnull
{
    
}