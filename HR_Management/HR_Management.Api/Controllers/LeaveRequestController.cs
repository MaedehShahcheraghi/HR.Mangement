using HR_Management.Application.DTOs.LeaveRequest;
using HR_Management.Application.Features.LeaveRequests.Requests.Commands;
using HR_Management.Application.Features.LeaveRequests.Requests.Queries;
using HR_Management.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<LeaveRequestController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> Get()
        {
            var response = await _mediator.Send(new GetLeaveRequestsListRequest());
            return Ok(response);

        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {

            var response = await _mediator.Send(new GetLeaveRequestDetailRequest() { Id = id });
            return Ok(response);

        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveRequestsDto createLeaveRequests)
        {
            var command = new CreateLeaveRequestsCommand() { LeaveRequestDto = createLeaveRequests };
            var response=   await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto updateLeaveRequest)
        {
            var command = new UpdateLeaveRequestCommand()
            {
                Id = id,
                LeaveRequestDto = updateLeaveRequest   
            };
            await  _mediator.Send(command);

            return Ok();
        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command=new DeleteLeaveRequestCommand() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut("ChangeApproval/{id}")]
        public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDto? requestApprovalDto)
        {
            var command = new UpdateLeaveRequestCommand() { Id = id, ChangeLeaveRequestApprovealDto = requestApprovalDto };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
