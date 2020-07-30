using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBS.Models.ViewModel
{
    public class AdminVM
    {
        public BGroup BGroup { get; set; }

        public Hospital Hospital { get; set; }

        public Inventory Inventory { get; set; }

        //DropDown Lists
        public IEnumerable<SelectListItem> BGroupList { get; set; }

        public IEnumerable<SelectListItem> HospitalsList { get; set; }
    }
}
