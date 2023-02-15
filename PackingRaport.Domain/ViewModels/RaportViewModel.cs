using PackingRaport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingRaport.Domain.ViewModels
{
    public class RaportViewModel
    {
        public DateTime StartProductionTime { get; set; }
        public DateTime? EndProductionTime { get; set; }

        public User User { get; set; }
        public ICollection<int> Products { get; set; }
        public ICollection<Container> Containers { get; set; }
    }
}
