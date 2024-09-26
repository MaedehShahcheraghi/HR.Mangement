using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models.LeaaveRequestModels;
using HR_Management.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.MVC.Controllers
{
    public class LeaveRequsetController : Controller
    {
        private readonly ILeaveRequestService _leaveRequestService;

        public LeaveRequsetController(ILeaveRequestService leaveRequestService)
        {
            this._leaveRequestService = leaveRequestService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int LeaveRequestId = 0, string approvedCheckbox=null)
        {
           
            if (LeaveRequestId!=0 && approvedCheckbox!=null)
            {
                bool status;
                if (approvedCheckbox== "on")
                {
                    status = true;
                }
                else
                {
                    status= false;
                }
                await _leaveRequestService.ChangeApprovalAsync(LeaveRequestId, status);
            }
            var leaverequsets = await _leaveRequestService.GetLeaveRequestAsync();
            return View(leaverequsets);
        }
        public async Task<IActionResult> Details(int id)
        {
            var leaverequsets=await _leaveRequestService.GetLeaveRequestDatailByIdAsync(id);
            return View(leaverequsets);
        }
        
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLeaveRequestVM createLeaveRequest)
        {
            if (!ModelState.IsValid) {
                ModelState.AddModelError("", "INUPTS ARE NOT VALID");
                return View(createLeaveRequest);    
            }
            var response = await _leaveRequestService.CreateLeaveRequest(createLeaveRequest);
            if (response.Success) {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", response.ValidationErrors);
            return View(createLeaveRequest);
            
        }

        public async Task<IActionResult> Edit(int id)
        {
            var leaverequst=await  _leaveRequestService.GetLeaveRequestDatailByIdAsync(id);
            return View(leaverequst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,UpdateLeaveRequstVM updateLeaveRequst)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "INUPTS ARE NOT VALID");
                return View(updateLeaveRequst);
            }
            var response = await _leaveRequestService.EditLeaveRequestAsync(id,updateLeaveRequst);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", response.ValidationErrors);
            return View(updateLeaveRequst);
        }
        public async Task<ActionResult> Delete(int id)
        {

            var response = await _leaveRequestService.DeleteLeaveRequestAsync(id);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }

    }
}
