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
    public class Branch : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public AdminVM AVM { get; set; }

        public Branch(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBranch(int? id)
        {
            AVM = new AdminVM()
            {
                Branch = new Models.Branch(),
                HospitalsList = _unitofWork.Hospital.GetDropDownListForHospitals()
            };

            if(id != null)
            {
                AVM.Branch = _unitofWork.Branch.Get(id.GetValueOrDefault());
            }

            return View(AVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBranch()
        {
            if (ModelState.IsValid)
            {
                if(AVM.Branch.Id == 0)
                {
                    _unitofWork.Branch.Add(AVM.Branch);
                }
                else
                {
                    _unitofWork.Branch.Update(AVM.Branch);
                }

                _unitofWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                AVM.HospitalsList = _unitofWork.Hospital.GetDropDownListForHospitals();

                return View(AVM);
            }
        }

        public IActionResult Details(int id)
        {
            var bFromDb = _unitofWork.Branch.GetFirstOrDefault(filter: i => i.Id == id, includeProperties: "Hospital");

            return View(bFromDb);
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Branch.GetAll(includeProperties: "Hospital") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var bFromDb = _unitofWork.Branch.Get(id);

            if(bFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Branch!" });
            }

            _unitofWork.Branch.Remove(bFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Branch Deleted Successfully!" });
        }

        #endregion
    }
}
