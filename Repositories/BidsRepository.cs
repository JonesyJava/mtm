using System.Data;
using Dapper;
using mtm.Models;

namespace Repositories
{
    public class BidsRepository
    {
        private readonly IDbConnection _db;
        public BidsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Bid Create(Bid newBid)
        {
            string sql = @"
            INSERT INTO bids
            (jobsId, contractorsId)
            VALUES
            (@JobsId, @ContractorsId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newBid);
            newBid.Id = id;
            return newBid;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM bids WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}