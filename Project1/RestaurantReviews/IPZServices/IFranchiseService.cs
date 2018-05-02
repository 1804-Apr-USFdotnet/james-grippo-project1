using System;
using System.Collections.Generic;
using System.Text;
using PZModels;

namespace IPZServices
{
    public interface IFranchiseService
    {
        List<Franchise> AllFranchises();
        List<Franchise> FranchiseById();
        List<Franchise> GetGenre();
    }
}
