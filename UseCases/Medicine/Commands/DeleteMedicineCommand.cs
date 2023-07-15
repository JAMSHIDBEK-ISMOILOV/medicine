using System;
using MediatR;
using Medicine.WebApi.Abstractions;
using Medicine.WebApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Medicine.WebApi.UseCases.Medicine.Commands
{
	public class DeleteMedicineCommand : ICommand<Unit>
	{
		public int Id { get; set; }
	}

    public class DeleteMedicineCommandHandler : ICommandHandler<DeleteMedicineCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMedicineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMedicineCommand request, CancellationToken cancellationToken)
        {
            var medicine = await _context.Medicine.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (medicine == null)
            {
                throw new MedicineNotFoundException();
            }

            _context.Medicine.Remove(medicine);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

