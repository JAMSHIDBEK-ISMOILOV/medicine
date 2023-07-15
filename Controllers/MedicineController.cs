using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Medicine.WebApi.UseCases.Medicine.Commands;
using Medicine.WebApi.UseCases.Medicine.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Medicine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMedicineCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMedicineCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeleteMedicineCommand() { Id = id});
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medicines = await _mediator.Send(new GetAllMedicinesQuery());
            if (medicines is null)
            {
                return Ok("");
            }
            return Ok(medicines);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var medicine = await _mediator.Send(new GetMedicineByIdQuery { Id = id });
            if (medicine is null)
            {
                return Ok("");
            }
            return Ok(medicine);
        }
    }
}

