using System.ComponentModel.DataAnnotations;

namespace HR_Management.MVC.Models.LeaaveRequestModels
{
    public class LeaveRequestVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "LeaveType")]
        public LeaveTypeDtoVm LeaveType { get; set; }

        [Required]
  
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}
