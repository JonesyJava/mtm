using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using mtm.Models;

namespace Repositories
{
    public class JobsRepository
    {
        private readonly IDbConnection _db;
        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal Job Create(Job newJob)
        {
            string sql = @"
            INSERT INTO jobs
            (name, description, price)
            VALUES
            (@Name, @Description, @Price);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newJob);
            newJob.Id = id;
            return newJob;
        }

        internal IEnumerable<Job> GetAll()
        {
            string sql = @"SELECT * FROM jobs;";
            return _db.Query<Job>(sql);
        }
        internal Job GetById(int id)
        {
            string sql = @"SELECT * FROM jobs WHERE id = @id;";
            return _db.QueryFirstOrDefault<Job>(sql, new { id });
        }


        internal Job Edit(Job updated)
        {
            string sql = @"
            UPDATE jobs
            SET
                name = @Name,
                description = @Description,
                price = @Price
                WHERE id = @id;";
            _db.Execute(sql, updated);
            return updated;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM jobs WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }

        internal IEnumerable<BidViewModel> GetJobsByContractorId(int id)
        {
            string sql = @"SELECT
            j.*,
            bid.id AS BidId
            FROM bid 
            JOIN jobs j ON j.id = bid.jobId
            WHERE contractorId = @id;";
            return _db.Query<BidViewModel>(sql, new { id });
        }
    }
}