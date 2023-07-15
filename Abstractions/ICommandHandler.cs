using System;
using MediatR;

namespace Medicine.WebApi.Abstractions
{
	public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
		where TRequest : ICommand<TResponse>
	{
	}
}

