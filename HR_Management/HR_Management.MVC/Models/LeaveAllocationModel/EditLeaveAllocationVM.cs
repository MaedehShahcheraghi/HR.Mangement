using System.ComponentModel.DataAnnotations;

namespace HR_Management.MVC.Models.LeaveAllocationModel
{
    public class EditLeaveAllocationVM
    {
        [Required]
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Priod { get; set; }
    }
}
