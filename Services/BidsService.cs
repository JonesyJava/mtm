using mtm.Models;
using Repositories;

namespace Services
{
    public class BidsService
    {
        private readonly BidsRepository _repo;

        public BidsService(BidsRepository repo)
        {
            _repo = repo;
        }
        internal Bid Create(Bid newBid)
        {
            return _repo.Create(newBid);
        }

        internal void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}