﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_Demo.Interfaces
{
    public interface IInvestmentAccount : IBasicAccount
    {
        void Buyshares(int numberOfShares);
        void SellShares(int numberOfShares);
    }
}
