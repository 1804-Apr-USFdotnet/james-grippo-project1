using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IPZServices;
using PZModels;
using PZRepositoryInterface;

namespace PZServices
{
    public class FranchiseService : IFranchiseService
    {
        private readonly IFranchiseRepo _franchiseRepo;

        public FranchiseService(IFranchiseRepo franchiseRepo)
        {
            _franchiseRepo = franchiseRepo;
        }

        public List<Franchise> AllFranchises()
        {
            return _franchiseRepo.GetAll().ToList();
        }

        public Franchise FranchiseById(int id)
        {
            return _franchiseRepo.GetById(id);
        }

        public Franchise FranchiseByName(string name)
        {
            return _franchiseRepo.GetByName(name);
        }

        public List<Franchise> GetByGenre(string genre)
        {
            IEnumerable<Franchise> query = _franchiseRepo.GetAll();
            return query.Where(x => x.Genre == genre).ToList();
        }

        public List<Franchise> SearchFranchises(string search)
        {
            IEnumerable<Franchise> query = _franchiseRepo.GetAll();
            return query.Where(x => Regex.IsMatch(x.Name,search)).ToList();
        }

        public void AddFranchise(Franchise franchise)
        {
            _franchiseRepo.Add(franchise);
        }

        public void RemoveFranchise(Franchise franchise)
        {
            _franchiseRepo.Remove(franchise);
        }

        public void UpdateFranchise(Franchise franchise)
        {
            _franchiseRepo.Update(franchise);
        }
    }
}
