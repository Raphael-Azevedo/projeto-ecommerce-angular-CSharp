using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SanclerAPI.DTO;
using SanclerAPI.HATEOAS.Conteiners;
using SanclerAPI.Models;
using SanclerAPI.Repository.Interfaces;
using SanclerAPI.Services.Interfaces;

namespace SanclerAPI.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;
        private readonly HATEOAS.HATEOAS _hateoas;

        public ProductServices(IUnitOfWork uof, IMapper mapper)
        {
            _mapper = mapper;
            _uof = uof;

            _hateoas = new HATEOAS.HATEOAS("localhost:5001/api/v1/Products");
            _hateoas.AddAction("GET_INFO", "GET");
            _hateoas.AddAction("DELETE_PRODUCT", "DELETE");
        }

        public async Task Create(CreateProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            product.Status = true;
            await _uof.ProductRepository.Add(product);
            await _uof.Commit();
        }

        public async Task Delete(int id)
        {
            await _uof.ProductRepository.BoleanDelete(id);
            await _uof.Commit();
        }

        public async Task<IEnumerable<ProductConteiner>> Get(int skip, int take)
        {
            var products = await _uof.ProductRepository.GetAll(skip: skip, take: take)
                                                       .ToListAsync();
                                                           
            List<ProductConteiner> productConteiner = new List<ProductConteiner>();
            foreach (var product in products)
            {
                ProductConteiner conteiner = new ProductConteiner();
                conteiner.product = product;
                conteiner.links = _hateoas.GetActions(product.Id.ToString());
                productConteiner.Add(conteiner);
            }

            return productConteiner;
        }

        public async Task<ProductConteiner> GetById(int id)
        {
            var product = await _uof.ProductRepository.GetById(p => p.Id == id && p.Status == true);
            ProductConteiner conteiner = new ProductConteiner();
            conteiner.product = product;
            conteiner.links = _hateoas.GetActions(product.Id.ToString());

            return conteiner;
        }

        public async Task Update(int id, UpdateProductDTO productDTO)
        {
            var product = await _uof.ProductRepository.GetById(p => p.Id == id);
            
            product.Title = productDTO.Title;
            product.Descriptions = productDTO.Descriptions;
            product.Price = productDTO.Price;

            _uof.ProductRepository.Update(product);
            await _uof.Commit();
        }
    }
}