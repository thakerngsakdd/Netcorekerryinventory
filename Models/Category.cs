﻿using System;
using System.Collections.Generic;

namespace NetcoreKerryInventory.Models
{
    public partial class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = null!;
        public int CategoryStatus { get; set; }
    }
}
