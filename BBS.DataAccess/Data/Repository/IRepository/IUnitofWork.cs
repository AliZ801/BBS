using System;
using System.Collections.Generic;
using System.Text;

namespace BBS.DataAccess.Data.Repository.IRepository
{
    public interface IUnitofWork : IDisposable
    {
        IBGroupRepo BGroup { get; }

        IHospitalRepo Hospital { get; }

        IBranchRepo Branch { get; }

        IInventoryRepo Inventory { get; }

        void Save();
    }
}
