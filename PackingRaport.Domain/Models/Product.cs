using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingRaport.Domain.Models
{
    public class Product
    {
        public int Id  { get; set; }
        public string ProductName { get; set; }
        public int RaportId { get; set; }

        public Raport Raports { get; set; }
    }
}
