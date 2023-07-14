using System;
using MediatR;

namespace Medicine.WebApi.Data.DependencyInjections
{
	public static class DependencyInjectionForMediator
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddMediatR(typeof(DependencyInjectionForMediator).Assembly);

			return services;
		}	
	}
}

