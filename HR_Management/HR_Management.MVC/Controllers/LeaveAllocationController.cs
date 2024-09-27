using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Models.LeaaveRequestModels;
using HR_Management.MVC.Models.LeaveAllocationModel;
using HR_Management.MVC.Services;
using HR_Management_Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.MVC.Controllers
{
    public class LeaveAllocationController: Controller
    {
        private readonly ILeaveAllocationService leaveAllocationService;

        public LeaveAllocationController(ILeaveAllocationService leaveAllocationService)
        {
            this.leaveAllocationService = leaveAllocationService;
        }
        // GET: LeaveAllocationRepository
        public async Task<ActionResult> Index()
        {
            var leaveAllocations = await leaveAllocationService.GetAllLeaveAllocation();
            return View(leaveAllocations);
        }

        // GET: LeaveAllocationRepository/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var leaveAllocation=await leaveAllocationService.GetLeaveAllocationById(id);
            return View(leaveAllocation);
        }

        // GET: LeaveAllocationRepository/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: LeaveAllocationRepository/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveAllocationVM leaveAllocationVM)
        {
            try
            {
                var response=await leaveAllocationService.AddLeaveAllocation(leaveAllocationVM);
                if (response.Success)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("", response.ValidationErrors);
                    return View(leaveAllocationVM);
                }

                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(leaveAllocationVM);
            }
        }

        // GET: LeaveAllocationRepository/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var leaveallocation=await leaveAllocationService.GetLeaveAllocationByIdForEdit(id);
            return View(leaveallocation);
        }

        // POST: LeaveAllocationRepository/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditLeaveAllocationVM editLeaveAllocationVM)
        {
            try
            {
                var response = await leaveAllocationService.EditLeaveAllocation(id,editLeaveAllocationVM);
                if (response.Success) {
                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("", response.ValidationErrors);
                    return View(editLeaveAllocationVM);
                }

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(editLeaveAllocationVM);
            }
        }

        // GET: LeaveAllocationRepository/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await leaveAllocationService.DeleteLeaveAllocation(id);
            if (response.Success)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
