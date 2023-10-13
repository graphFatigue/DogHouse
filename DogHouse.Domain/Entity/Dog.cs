﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse.Domain.Entity
{
    public class Dog: BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int TailLength { get; set; }
        public int Weight { get; set; }
    }
}
