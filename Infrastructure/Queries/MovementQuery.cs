using Domain.Aggregates.Movements;
using Domain.Aggregates.Movements.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public class MovementQuery : IMovementQuery
    {
        private readonly SqlServerContext _context;

        public MovementQuery(SqlServerContext context)
        {
            _context = context;
        }

        public Task<List<Movement>> GetAllMovementsByCurrentDay(DateTime date)
        {
            //var result = _context.Movements.Where(p => p.date.Date == date.Date).ToListAsync();
            var result = _context.Movements.ToListAsync();
            return result;
        }
    }
}
