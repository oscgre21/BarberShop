using System;
using BarberShop.BL.DTOs.Global;
using BarberShop.Services.Base;
using BarberShop.Domain.Entities.Global;
using BarberShop.Domain.UnitOfWork;
using BarberShop.Domain.Contexts;
using AutoMapper;
using BarberShop.Domain.Entities.Products;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BarberShop.Services.Global
{
 
    public interface IProductServices : IBaseEntityService<Product, ProductsDTO>
    {
        Task<List<ProductsDTO>> getListProducts();
        Task<List<ProductsDTO>> getListServices();
        Task<ProductAndServicesDTO> getProductAndServices();
    }
    public class ProductServices : BaseEntityService<Product, ProductsDTO>, IProductServices
    {
        public ProductServices(IUnitOfWork<BaseDBContext> uow, IMapper mapper)
           : base(uow, mapper)
        {

        }
        public async Task<List<ProductsDTO>> getListProducts() {
            var ident = (await _uow.GetRepository<Product>().Get(x=>x.ProductType.Equals("PRODUCT"), null, null, null, false)).ToList();
            var producto = _mapper.Map<List<ProductsDTO>>(ident);
            return producto;
        }
        public async Task<List<ProductsDTO>> getListServices()
        {
            var ident = (await _uow.GetRepository<Product>().Get(x => x.ProductType.Equals("SERVICIO"), null, null, null, false)).ToList();
            var producto = _mapper.Map<List<ProductsDTO>>(ident);
            return producto;
        }
        public async Task<ProductAndServicesDTO> getProductAndServices()
        {
            var ps = new ProductAndServicesDTO();
            ps.products = (await getListProducts());
            ps.services = (await getListServices());
            return ps;
        }
    }
}
