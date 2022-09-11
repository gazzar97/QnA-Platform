using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QnA_Platform.Application.Features.Users.Queries;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QnA_Platform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("login",Name ="Login")]
        public async Task<ActionResult<GetIDAfterLoginQueryResponse>> Login([FromBody] User user)
        {
            try
            {

                var getIDAfterLoginQueryResponse = await _mediator.Send(new GetIDAfterLoginQuery() { UserName = user.UserName,Password = user.Password});
                return Ok(getIDAfterLoginQueryResponse);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
    }
}
