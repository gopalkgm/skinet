using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public StoreContext Context { get; }
        public GenericRepository(StoreContext context)
        {
            this.Context = context;

        }
        public async Task<T> GetByIdAsync(int id)
        {
                return await Context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllsync()
        {
                return await Context.Set<T>().ToListAsync();
        }

        private IQueryable<T>  ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(Context.Set<T>().AsQueryable(),spec);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
              return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
              return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
    }
}