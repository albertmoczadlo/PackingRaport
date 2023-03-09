﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingRaport.Domain.Models;

namespace PackingRaport.Domain.InterfaceRepository
{
    public interface IRaportRepositories
    {
        IEnumerable<Raport> GetAllRaports();
        Raport GetById(int id);
        void AddRaport(Raport raport);
        IEnumerable<Container> GetContainers();

        void RemoveRaport(Raport raport);
        void Update(Raport raport);
       
    }
}
