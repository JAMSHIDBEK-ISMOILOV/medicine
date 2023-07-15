using System;
using MediatR;

namespace Medicine.WebApi.Abstractions
{
	public interface ICommand<out TResponse> : IRequest<TResponse>
	{
	}
}

