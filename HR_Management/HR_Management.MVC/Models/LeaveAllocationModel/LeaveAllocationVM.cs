using System.ComponentModel.DataAnnotations;

namespace HR_Management.MVC.Models.LeaveAllocationModel
{
    public class LeaveAllocationVM
    {
        [Required]
        public int Id { get; set; }
       
        [Display(Name = "LeaveType")]
        public LeaveTypeDtoVm LeaveType { get; set; }
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Priod { get; set; }
    }
}
