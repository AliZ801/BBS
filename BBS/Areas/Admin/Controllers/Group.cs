using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBS.DataAccess.Data.Repository.IRepository;
using BBS.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BBS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Group : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public AdminVM AVM { get; set; }

        public Group(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddGroup(int? id)
        {
            AVM = new AdminVM() { BGroup = new Models.BGroup() };

            if(id != null)
            {
                AVM.BGroup = _unitofWork.BGroup.Get(id.GetValueOrDefault());
            }

            return View(AVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddGroup()
        {
            if (ModelState.IsValid)
            {
                if(AVM.BGroup.Id == 0)
                {
                    _unitofWork.BGroup.Add(AVM.BGroup);
                }
                else
                {
                    _unitofWork.BGroup.Update(AVM.BGroup);
                }

                _unitofWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(AVM);
            }
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.BGroup.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var gFromDb = _unitofWork.BGroup.Get(id);

            if(gFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Blood Group!" });
            }

            _unitofWork.BGroup.Remove(gFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Blood Group Deleted Successfully!" });
        }

        #endregion
    }
}
