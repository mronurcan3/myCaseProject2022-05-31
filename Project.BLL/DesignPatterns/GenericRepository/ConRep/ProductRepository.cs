﻿using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.ConRep
{
    public class ProductRepository:BaseRepository<Product>
    {
        public ProductRepository()
        {

        }
    }
}
