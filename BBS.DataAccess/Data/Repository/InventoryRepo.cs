using BBS.DataAccess.Data.Repository.IRepository;
using BBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBS.DataAccess.Data.Repository
{
    public class InventoryRepo : Repository<Inventory>, IInventoryRepo
    {
        private readonly ApplicationDbContext _db;

        public InventoryRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Inventory inventory)
        {
            var iFromDb = _db.Inventory.FirstOrDefault(i => i.Id == inventory.Id);

            iFromDb.BloodId = inventory.BloodId;
            iFromDb.HospitalId = inventory.HospitalId;
            iFromDb.BranchId = inventory.BranchId;
            iFromDb.Quantity = inventory.Quantity;

            _db.SaveChanges();
        }
    }
}
