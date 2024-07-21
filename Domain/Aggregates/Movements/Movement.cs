using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.Movements
{
    public class Movement
    {
        public int movementId { get; set; }
        public TypeMovement typeMovement { get; set; }
        public decimal value { get; set; }
        public DateTime date { get; set; }
        public City city { get; set; }
        public int customerID { get; set; }
        public int accountId { get; set; }
    }
}
