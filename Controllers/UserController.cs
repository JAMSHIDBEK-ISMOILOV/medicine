using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Medicine.WebApi.UseCases.User.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Medicine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Name/{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            var medicine = await _mediator.Send(new GetMedicineByNameQuery { Name = name });
            if (medicine == null)
            {
                return Ok("");
            }
            return Ok(medicine);
        }

        [HttpGet("Structure/{structure}")]
        public async Task<IActionResult> GetByStructure([FromRoute] string structure)
        {
            var medicines = await _mediator.Send(new GetAllMedicineByStructureQuery { Structure = structure });
            if (medicines.Count == 0)
            {
                return Ok("");
            }
            return Ok(medicines);
        }
    }
}

