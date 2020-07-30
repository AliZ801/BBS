using BBS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBS.DataAccess.Data.Repository.IRepository
{
    public interface IInventoryRepo : IRepository<Inventory>
    {
        void Update(Inventory inventory);
    }
}
