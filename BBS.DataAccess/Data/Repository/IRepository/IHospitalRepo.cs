using BBS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBS.DataAccess.Data.Repository.IRepository
{
    public interface IHospitalRepo : IRepository<Hospital>
    {
        IEnumerable<SelectListItem> GetDropDownListForHospitals();

        void Update(Hospital hospital);
    }
}
