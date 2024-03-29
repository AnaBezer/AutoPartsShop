﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Application.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
