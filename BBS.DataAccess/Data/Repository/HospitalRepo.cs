using BBS.DataAccess.Data.Repository.IRepository;
using BBS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.DataAccess.Data.Repository
{
    public class HospitalRepo : Repository<Hospital>, IHospitalRepo
    {
        private readonly ApplicationDbContext _db;

        public HospitalRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetDropDownListForHospitals()
        {
            return _db.Hospital.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Hospital hospital)
        {
            var hFromDb = _db.Hospital.FirstOrDefault(i => i.Id == hospital.Id);

            hFromDb.Name = hospital.Name;

            _db.SaveChanges();
        }
    }
}
