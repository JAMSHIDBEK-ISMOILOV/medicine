using System;
using MediatR;

namespace Medicine.WebApi.Abstractions
{
	public interface IQuery<out TResponse> : IRequest<TResponse>
	{
	}
}

