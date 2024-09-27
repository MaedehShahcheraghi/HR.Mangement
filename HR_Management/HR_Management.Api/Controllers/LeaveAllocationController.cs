using HR_Management.Application.DTOs.LeaveAllocation;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveAllocations.Requests.Commands;
using HR_Management.Application.Features.LeaveAllocations.Requests.Queries;
using HR_Management.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<LeaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveRequestDetailRequest() { Id=id} );
            return Ok(leaveAllocations);
        }

        // POST api/<LeaveAllocationController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveAllocationDto createLeaveAllocation)
        {
            var command = await _mediator.Send(new CreateLeaveAllocationsCommand() { LeaveAllocationDto = createLeaveAllocation });
            return Ok(command);
        }

        // PUT api/<LeaveAllocationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveAllocationDto updateLeaveAllocation)
        {
            var command=await _mediator.Send(new UpdateLeaveAllocationCommand() { LeaveAllocationDto = updateLeaveAllocation });
            return Ok();
        }

        // DELETE api/<LeaveAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command=await _mediator.Send(new DeleteLeaveAllocationCommand() {  Id = id });  
            return Ok();
        }
    }
}
