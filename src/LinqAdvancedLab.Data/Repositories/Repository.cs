using LinqAdvancedLab.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
namespace LinqAdvancedLab.Data.Repositories
{
    public class Repository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public Repository(AppDbContext context) => _context = context;

        public IEnumerable<T> Find(ISpecification<T> spec)
        {
            return _context.Set<T>().Where(spec.Criteria).ToList();
        }
    }
}
