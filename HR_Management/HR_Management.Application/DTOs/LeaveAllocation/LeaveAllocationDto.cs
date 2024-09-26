using HR_Management.Application.DTOs.Common;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management_Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Priod { get; set; }
    }
}
