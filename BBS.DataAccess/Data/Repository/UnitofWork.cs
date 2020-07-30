using BBS.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBS.DataAccess.Data.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _db;

        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;
            BGroup = new BGroupRepo(_db);
            Hospital = new HospitalRepo(_db);
            Inventory = new InventoryRepo(_db);
        }

        public IBGroupRepo BGroup { get; private set; }

        public IHospitalRepo Hospital { get; private set; }

        public IInventoryRepo Inventory { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
