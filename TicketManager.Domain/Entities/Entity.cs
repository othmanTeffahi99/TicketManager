using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Domain.Entities
{
    public class Entity<TKey> : IEntity
    {
        public TKey Id { get; set; } 
    }

    public interface IEntity
    {
    }
}
