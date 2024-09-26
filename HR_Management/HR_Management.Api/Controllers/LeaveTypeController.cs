using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Features.LeaveTypes.Requests.Queries;
using HR_Management.Application.Responses;
using HR_Management_Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leaveTypes);
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>>  Get(int id)
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeDetailRequest() { Id=id});
            return Ok(leaveTypes);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDto createLeaveType)
        {
            var response = await _mediator.Send(new CreateLeaveTypeCommand() { LeaveTypeDto = createLeaveType }) ;
            return Ok(response);
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> put(int id,[FromBody] LeaveTypeDto leaveTypeDto)
        {
            var command = new UpdateLeaveTypeCommand() { LeaveTypeDto = leaveTypeDto };
             await _mediator.Send(command);
            return Ok();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command =new DeleteLeaveTypeCommand() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
