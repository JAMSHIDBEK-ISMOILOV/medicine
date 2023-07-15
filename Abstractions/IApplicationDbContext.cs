using System;
using Microsoft.EntityFrameworkCore;

namespace Medicine.WebApi.Abstractions
{
	public interface IApplicationDbContext
	{
		DbSet<Entities.Medicine> Medicine { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}

