﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    public interface IDepositable
    {
        void DepositAmmount(decimal ammount, DateTime date);
    }
}
