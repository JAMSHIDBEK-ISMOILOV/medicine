using System;
using MediatR;
using Medicine.WebApi.Abstractions;
using Medicine.WebApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Medicine.WebApi.UseCases.Medicine.Commands
{
	public class UpdateMedicineCommand : ICommand<Unit>
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Structure { get; set; }
		public DateTime? CreateDate { get; set; }
		public DateTime? EndDate { get; set; }
	}

    public class UpdateMedicineCommandHandler : ICommandHandler<UpdateMedicineCommand, Unit>
    {
		private readonly IApplicationDbContext _context;

		public UpdateMedicineCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

        public async Task<Unit> Handle(UpdateMedicineCommand request, CancellationToken cancellationToken)
        {
			var medicine = await _context.Medicine.FirstOrDefaultAsync(x => x.Id == request.Id);

			if (medicine == null)
			{
				throw new Exception(nameof(MedicineNotFoundException));
			}

			medicine.Name = request.Name ?? medicine.Name;
			medicine.Structure = request.Structure ?? medicine.Structure;
			medicine.CreateDate = request.CreateDate ?? medicine.CreateDate;
			medicine.EndDate = request.EndDate ?? medicine.EndDate;

			_context.Medicine.Update(medicine);
			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
        }
    }
}

