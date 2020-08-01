using BBS.DataAccess.Data.Repository.IRepository;
using BBS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.DataAccess.Data.Repository
{
    public class BranchRepo : Repository<Branch>, IBranchRepo
    {
        private readonly ApplicationDbContext _db;

        public BranchRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetDropDownListBranch()
        {
            return _db.Branch.Select(i => new SelectListItem()
            {
                Text = i.Code,
                Value = i.Id.ToString()
            });
        }

        public void Update(Branch branch)
        {
            var bFromDb = _db.Branch.FirstOrDefault(i => i.Id == branch.Id);

            bFromDb.Code = branch.Code;
            bFromDb.City = branch.City;
            bFromDb.Address1 = branch.Address1;
            bFromDb.Address2 = branch.Address2;
            bFromDb.PostalCode = branch.PostalCode;
            bFromDb.HospitalId = branch.HospitalId;

            _db.SaveChanges();
        }
    }
}
