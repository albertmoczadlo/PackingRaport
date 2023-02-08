using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingRaport.Domain.Models
{
    public class Tank
    {
        public int Id { get; set; }
        public string Bath { get; set; }
        public string Cauldron { get; set; }
        public int ContainerId { get; set; }

        public Container Containers { get; set; }
    }
}
