using Domain.Aggregates.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.Movements.Interfaces
{
    public interface IMovementQuery
    {
        Task<List<Movement>> GetAllMovementsByCurrentDay(DateTime date);
    }
}
