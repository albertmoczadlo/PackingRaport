﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingRaport.Domain.Models;

namespace PackingRaport.Domain.InterfaceRepository
{
    public interface IUserRepository
    {
        User GetUserById(string id);
    }
}
