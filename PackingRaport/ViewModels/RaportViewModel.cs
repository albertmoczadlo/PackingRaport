using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PackingRaport.Domain.Models;

namespace PackingRaport.ViewModels
{
    public class RaportViewModel
    {
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }
        public DateTime StartProductionTime { get; set; }
        public DateTime? EndProductionTime { get; set; }
        public int Quantity { get; set; }
        public string Comments { get; set; }

    }
}
