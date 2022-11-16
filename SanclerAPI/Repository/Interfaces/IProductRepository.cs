using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SanclerAPI.Models;

namespace SanclerAPI.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task BoleanDelete(int id);
        IQueryable<Product> GetAll(int skip = 0, int take = 10);
    }
}