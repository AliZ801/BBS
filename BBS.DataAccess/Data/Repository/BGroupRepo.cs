using BBS.DataAccess.Data.Repository.IRepository;
using BBS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.DataAccess.Data.Repository
{
    public class BGroupRepo : Repository<BGroup>, IBGroupRepo
    {
        private readonly ApplicationDbContext _db;

        public BGroupRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetDropDownListForBGroup()
        {
            return _db.BGroup.Select(i => new SelectListItem()
            {
                Text = i.Group,
                Value = i.Id.ToString()
            });
        }

        public void Update(BGroup bGroup)
        {
            var gFromDb = _db.BGroup.FirstOrDefault(i => i.Id == bGroup.Id);

            gFromDb.Group = bGroup.Group;

            _db.SaveChanges();
        }
    }
}
