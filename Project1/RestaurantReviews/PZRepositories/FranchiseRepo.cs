using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PZModels;
using PZRepositoryInterface;

namespace PZRepositories
{
    class FranchiseRepo : IFranchiseRepo
    {
        private readonly PZRepoContext _pzRepoContext;

        public FranchiseRepo(PZRepoContext context)
        {
            _pzRepoContext = context;
        }
        public Franchise GetById(int id)
        {
            return _pzRepoContext.Franchises.First(x => x.FranchiseId == id);
        }

        public Franchise GetByName(string franchise)
        {
            return _pzRepoContext.Franchises.First(x => x.Name == franchise);
        }

        public IEnumerable<Franchise> GetAll()
        {
            return _pzRepoContext.Franchises;
        }


        public void Add(Franchise franchise)
        {
            _pzRepoContext.Franchises.Add(franchise);
            _pzRepoContext.SaveChanges();
        }

        public void Remove(Franchise franchise)
        {
            _pzRepoContext.Franchises.Remove(franchise);
            _pzRepoContext.SaveChanges();
        }

        public void Update(Franchise franchise)
        {
            var r = _pzRepoContext.Franchises.Find(franchise.FranchiseId);
            _pzRepoContext.Entry(r).CurrentValues.SetValues(franchise);
            _pzRepoContext.SaveChanges();
        }
    }
}
