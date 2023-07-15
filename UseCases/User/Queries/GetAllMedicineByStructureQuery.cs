using System;
using Medicine.WebApi.Abstractions;
using Medicine.WebApi.DTOs;
using Medicine.WebApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Medicine.WebApi.UseCases.User.Queries
{
	public class GetAllMedicineByStructureQuery : IQuery<List<MedicineViewModel>>
	{
		public string Structure { get; set; }
	}

    public class GetAllMedicineByStructureQueryHandler : IQueryHandler<GetAllMedicineByStructureQuery, List<MedicineViewModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllMedicineByStructureQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MedicineViewModel>> Handle(GetAllMedicineByStructureQuery request, CancellationToken cancellationToken)
        {
            return await _context.Medicine.Where(x => x.Structure.Contains(request.Structure))
                                                          .Select(x => new MedicineViewModel
                                                          {
                                                              Name = x.Name,
                                                              Structure = x.Structure,
                                                              CreateDate = x.CreateDate,
                                                              EndDate = x.EndDate
                                                          }
                                                          ).ToListAsync(cancellationToken);
        }
    }
}

