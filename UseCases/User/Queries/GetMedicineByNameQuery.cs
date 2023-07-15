using System;
using Medicine.WebApi.Abstractions;
using Medicine.WebApi.DTOs;
using Medicine.WebApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Medicine.WebApi.UseCases.User.Queries
{
	public class GetMedicineByNameQuery : IQuery<MedicineViewModel>
	{
		public string Name { get; set; }
	}

    public class GetMedicineByNameQueryHandler : IQueryHandler<GetMedicineByNameQuery, MedicineViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetMedicineByNameQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MedicineViewModel> Handle(GetMedicineByNameQuery request, CancellationToken cancellationToken)
        {
            var medicine = await _context.Medicine.FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken);
            if (medicine == null)
            {
                throw new MedicineNotFoundException();
            }

            return new MedicineViewModel
            {
                Name = medicine.Name,
                Structure = medicine.Structure,
                CreateDate = medicine.CreateDate,
                EndDate = medicine.EndDate
            };
        }
    }
}

