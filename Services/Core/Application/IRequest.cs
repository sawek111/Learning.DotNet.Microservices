namespace Core.Application;

public interface IRequest<TResponse> : MediatR.IRequest<TResponse>
{
}