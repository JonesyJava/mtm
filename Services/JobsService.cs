using System;
using System.Collections.Generic;
using mtm.Models;
using Repositories;

namespace mtm.Services
{
    public class JobsService
    {
        private readonly JobsRepository _repo;

        public JobsService(JobsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Job> GetAll()
        {
            return _repo.GetAll();
        }

        internal Job GetById(int id)
        {
            var data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        internal Job Create(Job newJob)
        {
            return _repo.Create(newJob);
        }

        internal Job Edit(Job updated)
        {
            var original = GetById(updated.Id);
            updated.Description = updated.Description != null ? updated.Description : original.Description;
            updated.Name = updated.Name != null && updated.Name.Length > 2 ? updated.Name : original.Name;
            updated.Price = updated.Price != null && updated.Price > 2 ? updated.Price : original.Price;
            return _repo.Edit(updated);
        }
        internal string Delete(int id)
        {
            var original = GetById(id);
            if (original == null)
            {
                throw new Exception("Invalid Delete Permissions");
            }
            _repo.Delete(id);
            return "DELETED";
        }
        internal IEnumerable<BidViewModel> GetJobsByContractorId(int id)
        {
            return _repo.GetJobsByContractorId(id);
        }

    }

}