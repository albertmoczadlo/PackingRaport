using Microsoft.AspNetCore.Mvc;
using PackingRaport.Domain.Models;

namespace PackingRaport.Helpers
{
    public class PackingRaportHelpers
    {
        [BindProperty(SupportsGet = true)]
        public string CurrentFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public int PageSize { get; set; } = 10;
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; } = 1;

        public List<Raport> Raports { get; set; }

    }
}
