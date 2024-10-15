using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManager.Domain.Entities;
using TicketManager.Domain.Repositories;
using TicketManager.Infrastructure.Common.Persistence;

namespace TicketManager.Infrastructure.Common.Repositories
{
    public class RepositoryBase<TEntity>(AppDbContext appDbContext) : IRepository<TEntity>
        where TEntity : class
    {
        private readonly AppDbContext _appDbContext = appDbContext;


        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token)
        {
            return await _appDbContext.Set<TEntity>().ToListAsync(token);
        }

        //TODO: change the type of id

        public async Task<TEntity?> FindByIdAsync(object id, CancellationToken token)
        {
            return await _appDbContext.Set<TEntity>().FindAsync((object?[]?)id, cancellationToken: token);
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken token)
        {
            var result = await _appDbContext.Set<TEntity>().AddAsync(entity, token);

            return result.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token)
        {
            return await Task.Run(() =>
             {
                 var result = _appDbContext.Set<TEntity>().Update(entity);
                 return result.Entity;
             }, token);

        }


        public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken token)
        {
            return await Task.Run(() =>
              {
                  var result = _appDbContext.Set<TEntity>().Remove(entity);
                  return result.Entity;
              }, token);
        }
    }
}
