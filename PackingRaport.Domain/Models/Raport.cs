using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingRaport.Domain.Models
{
    public class Raport
    {
        public int Id { get; set; }
        [DisplayName("Start")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartProductionTime { get; set; }

        [DisplayName("Koniec")]
        public DateTime? EndProductionTime { get; set; }
        public string UserId { get; set; }
        [DisplayName("Ilość")]
        [Range(0, 1000000, ErrorMessage = "Value must be between 0 and 1,000,000.")]
        public int Quantity { get; set; }
       

        public User User { get; set; }
        public Product Product { get; set; }
        public Container Containers { get; set; }
    }
}
