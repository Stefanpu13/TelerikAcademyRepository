﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Human
{
    public abstract class Human
    {
        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    
    }
}
