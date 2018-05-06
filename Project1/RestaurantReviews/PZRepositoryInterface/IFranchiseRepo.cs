using System;
using System.Collections.Generic;
using System.Text;
using PZModels;

namespace PZRepositoryInterface
{
    public interface IFranchiseRepo
    {
        Franchise GetById(int id);
        IEnumerable<Franchise> GetAll();
        void Add(Franchise franchise);
        void UpdateFranchises();
    }
}
