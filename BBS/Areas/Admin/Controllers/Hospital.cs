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
    public class Hospital : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public AdminVM AVM { get; set; }

        public Hospital(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddHospital(int? id)
        {
            AVM = new AdminVM() { Hospital = new Models.Hospital() };

            if(id != null)
            {
                AVM.Hospital = _unitofWork.Hospital.Get(id.GetValueOrDefault());
            }

            return View(AVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddHospital()
        {
            if (ModelState.IsValid)
            {
                if(AVM.Hospital.Id == 0)
                {
                    _unitofWork.Hospital.Add(AVM.Hospital);
                }
                else
                {
                    _unitofWork.Hospital.Update(AVM.Hospital);
                }

                _unitofWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(AVM);
            }
        }

        public IActionResult Details(int id)
        {
            var hFromDb = _unitofWork.Hospital.Get(id);

            return View(hFromDb);
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Hospital.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var hFromDb = _unitofWork.Hospital.Get(id);

            if(hFromDb == null)
            {
                return Json(new { success = false, message = "Error Deleting Hospital Record!" });
            }

            _unitofWork.Hospital.Remove(hFromDb);
            _unitofWork.Save();

            return Json(new { success = true, message = "Hospital Record Deleted Successfully!" });
        }

        #endregion
    }
}
