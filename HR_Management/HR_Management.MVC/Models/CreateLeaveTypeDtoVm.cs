using System.ComponentModel.DataAnnotations;

namespace HR_Management.MVC.Models
{
    public class CreateLeaveTypeDtoVm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="The Defult Number Of Day")]
        public int DefaultDay { get; set; }
    }
}
