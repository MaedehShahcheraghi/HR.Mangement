using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.Features.LeaveTypes.Handlers.Commands;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Profiles;
using HR_Management.Application.Responses;
using HR_Management.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HR_Management.Application.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTest
    {
        Mock<ILeaveTypeRepository> _LeavetypeRepository;
        IMapper _mapper;
        public CreateLeaveTypeCommandHandlerTest()
        {
            _LeavetypeRepository = MockLeaveTypeRepository.GetLeaveTypeReposittory();
            var mapperconfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = mapperconfig.CreateMapper();
        }

        [Fact]
        public async Task CreateLeaveTypeCommandHandlerTestMethod()
        {
            var handel=new CreateLeaveTypeCommandHandler(_LeavetypeRepository.Object,_mapper);
            var result = await handel.Handle(new CreateLeaveTypeCommand()
            {
                LeaveTypeDto = new DTOs.LeaveType.CreateLeaveTypeDto()
                {
                    DefaultDay = 5,
                    Name = "vacation2"
                }
            }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse>();
            var leavetype = await _LeavetypeRepository.Object.GetAll();
            leavetype.Count.ShouldBe(3);
        }
    }
}
