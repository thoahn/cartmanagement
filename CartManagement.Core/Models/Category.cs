﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagement.Core.Models
{
    public class Category
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
