using HR_Management.Application.DTOs.LeaveType;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;
using HR_Management_Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.MVC.Controllers
{
    [Authorize]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;
        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
                _leaveTypeService = leaveTypeService;
        }
        // GET: LeaveTypesController
        public async Task<ActionResult> Index()
        {
            var leavetypes=await _leaveTypeService.GetLeaveTypes();
            return View(leavetypes);
        }

        // GET: LeaveTypesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var leavetype=await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(leavetype);
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeDtoVm createLeaveTypeDtoVm)
        {
            try
            {
                var response = await _leaveTypeService.CreateLeaveType(createLeaveTypeDtoVm);
                if (response.Success) { 
                    return RedirectToAction("Index");
                }
               
                ModelState.AddModelError("", response.ValidationErrors); 
                return View(createLeaveTypeDtoVm);

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(createLeaveTypeDtoVm);
            }
        }

        // GET: LeaveTypesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var leavetype = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(leavetype);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LeaveTypeDtoVm leaveType)
        {
            try
            {
                var response = await _leaveTypeService.UpdateLeaveType(id, leaveType);
                if (response.Success) {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", response.ValidationErrors);
                return View(leaveType);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(leaveType);
            }
        }

        // GET: LeaveTypesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            
                var response = await _leaveTypeService.DeleteLeavetype(id);
                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
             return BadRequest();
        }

        // POST: LeaveTypesController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        var response = await _leaveTypeService.DeleteLeavetype(id);
        //        if (response.Success)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        ModelState.AddModelError("", response.ValidationErrors);
        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //        return View();
        //    }
        //}
    }
}
