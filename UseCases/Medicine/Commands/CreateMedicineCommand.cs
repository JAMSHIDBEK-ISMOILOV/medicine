using System;
using Medicine.WebApi.Abstractions;
using Medicine.WebApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Medicine.WebApi.UseCases.Medicine.Commands
{
	public class CreateMedicineCommand : ICommand<int>
	{
		public string Name { get; set; }
		public string Structure { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CreateMedicineCommandHandler : ICommandHandler<CreateMedicineCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateMedicineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMedicineCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Medicine.AnyAsync(x => x.Name == request.Name && x.Structure == request.Structure &&
                                                 x.CreateDate == request.CreateDate && x.EndDate == request.EndDate,
                                                 cancellationToken))
            {
                throw new MedicineExistsException();
            }

            var medicine = new Entities.Medicine
            {
                Name = request.Name,
                Structure = request.Structure,
                CreateDate = request.CreateDate,
                EndDate = request.EndDate
            };

            await _context.Medicine.AddAsync(medicine);
            await _context.SaveChangesAsync(cancellationToken);

            return medicine.Id;
        }
    }
}

