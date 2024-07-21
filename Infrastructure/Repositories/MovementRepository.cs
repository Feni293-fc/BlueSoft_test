using Domain.Aggregates.Movements;
using Domain.Aggregates.Movements.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        private readonly SqlServerContext _context;

        public MovementRepository(SqlServerContext context)
        {
            _context = context;
        }

        public Task<Movement> Insert(Movement movement)
        {
            _context.Movements.Add(movement);
            _context.SaveChanges();
            Task<Movement?> task = _context.Movements.FirstOrDefaultAsync();
            return task;
        }
    }
}
