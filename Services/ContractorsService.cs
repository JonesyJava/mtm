using System;
using System.Collections.Generic;
using mtm.Models;
using Repositories;

namespace mtm.Services
{
    public class ContractorsService
    {
        private readonly ContractorsRepository _repo;

        public ContractorsService(ContractorsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Contractor> GetAll()
        {
            return _repo.GetAll();
        }

        internal Contractor GetById(int id)
        {
            var data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        internal Contractor Create(Contractor newContractor)
        {
            return _repo.Create(newContractor);
        }

        internal Contractor Edit(Contractor updated)
        {
            var original = GetById(updated.Id);
            updated.Age = updated.Age != null ? updated.Age : original.Age;
            updated.Name = updated.Name != null && updated.Name.Length > 2 ? updated.Name : original.Name;
            updated.Salary = updated.Salary != null && updated.Salary > 2 ? updated.Salary : original.Salary;
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
    }
}