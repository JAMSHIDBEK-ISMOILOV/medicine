using System;
using Medicine.WebApi.Abstractions;
using Medicine.WebApi.DTOs;
using Medicine.WebApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Medicine.WebApi.UseCases.Medicine.Queries
{
	public class GetMedicineByIdQuery : IQuery<MedicineViewModel>
	{
		public int Id { get; set; }
	}

    public class GetMedicineByIdQueryHandler : IQueryHandler<GetMedicineByIdQuery, MedicineViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetMedicineByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MedicineViewModel> Handle(GetMedicineByIdQuery request, CancellationToken cancellationToken)
        {
            var medicine = await _context.Medicine.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

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

