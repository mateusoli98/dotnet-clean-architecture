using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;

namespace CleanArchitecture.Persistence.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
