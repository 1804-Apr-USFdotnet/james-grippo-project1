using System;
using System.Collections.Generic;
using System.Text;
using PZModels;

namespace PZServices
{
    public interface IFranchiseService
    {
        List<Franchise> AllFranchises();
        Franchise FranchiseById(int id);
        Franchise FranchiseByName(string name);
        List<Franchise> GetByGenre(string genre);
        List<Franchise> SearchFranchises(string search);
        void AddFranchise(Franchise franchise);
        void RemoveFranchise(Franchise franchise);
        void UpdateFranchise(Franchise franchise);
    }
}
