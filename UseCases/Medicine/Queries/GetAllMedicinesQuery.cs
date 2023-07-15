using System;
using Medicine.WebApi.Abstractions;
using Medicine.WebApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Medicine.WebApi.UseCases.Medicine.Queries
{
	public class GetAllMedicinesQuery : IQuery<List<MedicineViewModel>>
	{
	}

    public class GetAllMedicineQueryHandler : IQueryHandler<GetAllMedicinesQuery, List<MedicineViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllMedicineQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MedicineViewModel>> Handle(GetAllMedicinesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Medicine
                .Select(x => new MedicineViewModel
                {
                    Name = x.Name,
                    Structure = x.Structure,
                    CreateDate = x.CreateDate,
                    EndDate = x.EndDate
                }).ToListAsync(cancellationToken);
        }
    }
}

