﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public abstract class BaseEntity
    {
        private static int _idCounter = 1;
        public int Id { get; private set; }

        protected BaseEntity()
        {
            Id = _idCounter++;
        }
    }
}
