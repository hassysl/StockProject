﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.Entities.Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
