using System;
using Medicine.WebApi.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Medicine.WebApi.Data.DependencyInjections
{
	public static class DependencyInjectionForDbContext
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
			{
				options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
			});

			return services;
		}
	}
}

