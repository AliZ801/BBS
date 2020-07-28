using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBS.Models.ViewModel
{
    public class AdminVM
    {
        public BGroup BGroup { get; set; }

        //DropDown Lists
        public IEnumerable<SelectListItem> BGroupList { get; set; }
    }
}
