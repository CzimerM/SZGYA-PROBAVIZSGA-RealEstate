﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
