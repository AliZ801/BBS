﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBS.DataAccess.Data.Repository.IRepository;
using BBS.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BBS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Inventory : Controller
    {
        private readonly IUnitofWork _unitofWork;

        [BindProperty]
        public AdminVM AVM { get; set; }

        public Inventory(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddInventory(int? id)
        {
            AVM = new AdminVM()
            {
                Inventory = new Models.Inventory(),
                BGroupList = _unitofWork.BGroup.GetDropDownListForBGroup(),
                HospitalsList = _unitofWork.Hospital.GetDropDownListForHospitals()
            };

            if(id != null)
            {
                AVM.Inventory = _unitofWork.Inventory.Get(id.GetValueOrDefault());
            }

            return View(AVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddInventory()
        {
            if (ModelState.IsValid)
            {
                if(AVM.Inventory.Id == 0)
                {
                    _unitofWork.Inventory.Add(AVM.Inventory);
                }
                else
                {
                    _unitofWork.Inventory.Update(AVM.Inventory);
                }

                _unitofWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                AVM.BGroupList = _unitofWork.BGroup.GetDropDownListForBGroup();
                AVM.HospitalsList = _unitofWork.Hospital.GetDropDownListForHospitals();

                return View(AVM);
            }
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitofWork.Inventory.GetAll(includeProperties: "BGroup,Hospital") });
        }

        #endregion
    }
}
