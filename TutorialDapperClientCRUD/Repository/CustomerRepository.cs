using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TutorialDapperClientCRUD.Models;

namespace TutorialDapperClientCRUD.Repository
{
    public class CustomerRepository
    {
        private readonly IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var result = await _dbConnection.GetAsync<Customer>(id);
            return result;
        }

        public async Task<IReadOnlyList<Customer>> GetAllAsync()
        {
            var result = await _dbConnection.GetAllAsync<Customer>();
            return result.ToList();
        }

        public async Task<Customer> AddAsync(Customer entity)
        {
            entity.CreationDate = DateTime.Now;
            entity.CustomerId = await _dbConnection.InsertAsync(entity);
            return entity;
        }

        public async Task AddListAsync(List<Customer> entity)
        {
            var data = DateTime.Now;
            entity.ForEach(x => x.CreationDate = data);

            await _dbConnection.InsertAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _dbConnection.DeleteAsync(new Customer { CustomerId = id });
            return result;
        }

        public async Task<bool> UpdateAsync(Customer entity)
        {
            var result = await _dbConnection.UpdateAsync(entity);
            return result;
        }
    }
}
