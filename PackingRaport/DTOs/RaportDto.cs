using PackingRaport.Domain.Models;

namespace PackingRaport.DTOs
{
    public class RaportDto
    {
        public DayOfWeek Day { get; set; }
        public DateTime StartProductionTime { get; set; }
        public DateTime? EndProductionTime { get; set; }
        public int Quantity { get; set; }
        public string Comments { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public Container Containers { get; set; }
    }


}
