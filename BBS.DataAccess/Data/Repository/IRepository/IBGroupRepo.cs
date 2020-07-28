using BBS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBS.DataAccess.Data.Repository.IRepository
{
    public interface IBGroupRepo : IRepository<BGroup>
    {
        IEnumerable<SelectListItem> GetDropDownListForBGroup();

        void Update(BGroup bGroup);
    }
}
