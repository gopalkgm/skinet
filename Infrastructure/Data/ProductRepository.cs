using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        public StoreContext Context { get; }
        public ProductRepository(StoreContext context)
        {
            this.Context = context;

        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await Context.Products
               .Include(p=>p.ProductBrand)
               .Include(p=>p.ProductType)
               .FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await Context.Products
               .Include(p=>p.ProductBrand)
               .Include(p=>p.ProductType)
               .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await Context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAync()
        {
            return await Context.ProductTypes.ToListAsync();
        }
    }
}