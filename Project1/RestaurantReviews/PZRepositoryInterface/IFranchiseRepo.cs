using System;
using System.Collections.Generic;
using System.Text;
using PZModels;

namespace PZRepositoryInterface
{
    public interface IFranchiseRepo
    {
        Franchise GetById(int id);
        Franchise GetByName(string franchise);
        IEnumerable<Franchise> GetAll();
        void Add(Franchise franchise);
        void Remove(Franchise franchise);
        void Update(Franchise franchise);
    }
}
