using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SanclerAPI.DTO;
using SanclerAPI.HATEOAS.Conteiners;
using SanclerAPI.Models;
using SanclerAPI.Repository.Interfaces;
using SanclerAPI.Services.Interfaces;

namespace SanclerAPI.Services
{
    public class InventoryServices : IInventoryServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;
        private readonly HATEOAS.HATEOAS _hateoas;

        public InventoryServices(IMapper mapper, IUnitOfWork uof)
        {
            _mapper = mapper;
            _uof = uof;

            _hateoas = new HATEOAS.HATEOAS("localhost:5001/api/v1/Inventory");
            _hateoas.AddAction("DELETE_INVENTORY", "DELETE");
        }

        public async Task Create(CreateInventoryDTO inventoryDto)
        {
            var inventory = _mapper.Map<Inventory>(inventoryDto);
            inventory.Product = await _uof.ProductRepository.GetById(i => i.Id == inventoryDto.ProductId);

            await _uof.InventoyRepository.Add(inventory);
            await _uof.Commit();
        }

        public async Task Delete(int id)
        {
            var Inventory = await _uof.InventoyRepository.GetById(c => c.Id == id);
            _uof.InventoyRepository.Delete(Inventory);
            await _uof.Commit();
        }

        public async Task<IEnumerable<InventoryConteiner>> GetByProductId(int id)
        {
            var Inventory = await _uof.InventoyRepository.GetByProductId(id);
            List<InventoryConteiner> conteiners = new List<InventoryConteiner>();

            foreach(var item in Inventory)
            {
                var inventoryDto = _mapper.Map<ReadInventoryDTO>(item);
                inventoryDto.product = item.Product;

                InventoryConteiner conteiner = new InventoryConteiner();
                conteiner.inventory = inventoryDto;
                conteiner.links = _hateoas.GetActions(item.Id.ToString());
                conteiners.Add(conteiner);
            }
            return conteiners;
        }

        public async Task Update(int id, UpdateInventoryDTO inventoryDto)
        {
            var inventory = await _uof.InventoyRepository.GetById(i => i.Id == id);
            inventory.Amount = inventoryDto.Amount;
            inventory.Size = inventoryDto.Size;
                
             _uof.InventoyRepository.Update(inventory);
            await _uof.Commit();
        }
    }
}