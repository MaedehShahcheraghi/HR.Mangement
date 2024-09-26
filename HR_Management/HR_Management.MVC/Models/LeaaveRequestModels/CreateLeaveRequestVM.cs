using System.ComponentModel.DataAnnotations;

namespace HR_Management.MVC.Models.LeaaveRequestModels
{
    public class CreateLeaveRequestVM
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public int LeaveTypeId { get; set; }
      
        [Required]
        public string RequestComments { get; set; }
    }
}
