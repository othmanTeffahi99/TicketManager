using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Domain.Entities;

namespace TicketManager.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token = default);
        Task<TEntity?> FindByIdAsync(object id, CancellationToken token = default);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token = default); 
        Task<TEntity> DeleteAsync(TEntity entity, CancellationToken token = default);


    }
}
