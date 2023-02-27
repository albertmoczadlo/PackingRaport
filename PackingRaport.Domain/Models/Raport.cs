using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingRaport.Domain.Models
{
    public class Raport
    {
        public int Id { get; set; }
        public DateTime StartProductionTime { get; set; }
        public DateTime? EndProductionTime { get; set; }
        public string UserId { get; set; }
       

        public User User { get; set; }
        public Product Product { get; set; }
        public Container Containers { get; set; }
    }
}
