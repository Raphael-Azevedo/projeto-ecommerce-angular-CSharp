using System.Collections.Generic;
using System.Threading.Tasks;
using SanclerAPI.DTO;
using SanclerAPI.HATEOAS.Conteiners;

namespace SanclerAPI.Services.Interfaces
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductConteiner>> Get(int skip, int take);
        Task<ProductConteiner> GetById(int id);
        Task Create(CreateProductDTO productDTO);
        Task Update(int id, UpdateProductDTO productDTO);
        Task Delete(int id);
    }
}