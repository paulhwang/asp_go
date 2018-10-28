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
    public class ListEntryClass
    {
        public int Id { get; set; }
        public object Data { get; set; }
        public int Index { get; set; }

        public void SetData(int id_val, object data_val, int index_val)
        {
            this.Id = id_val;
            this.Data = data_val;
            this.Index = index_val;
        }

    }
}
