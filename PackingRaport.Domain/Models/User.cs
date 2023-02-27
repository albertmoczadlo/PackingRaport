using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PackingRaport.Domain.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public String Surname { get; set; }

        public ICollection<Raport> Raports { get; set; }
    }
}
