/*
 ******************************************************************************
 *                                       
 *  Copyright (c) 2018 phwang. All rights reserved.
 *
 ******************************************************************************
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.PhwangUtils
{
    public class EncodeNumberClass
    {
        public static string EncodeNumber(int number_val, int size_val)
        {
            string str = number_val.ToString();

            var buf = "";
            for (var i = str.Length; i < size_val; i++)
            {
                buf = buf + "0";
            }
            buf = buf + str;
            return buf;
        }
    }
}
