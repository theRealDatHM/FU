﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main
{
    class AVeryBigSum
    {
        public static long aVeryBigSum(List<long> ar)
        {
            long sum = 0;
            foreach (var item in ar)
            {
                sum += item;
            }
            return sum;
        }
    }
}
