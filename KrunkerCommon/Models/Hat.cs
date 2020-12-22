﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrunkerCommon.Models
{
    public class Hat : Clothing
    {
        public Hat(string name, double price, ClothSize size, int amount, string imgpath, double discount = 0) : base(name, price, size, amount, imgpath, discount)
        {
        }
    }
}
