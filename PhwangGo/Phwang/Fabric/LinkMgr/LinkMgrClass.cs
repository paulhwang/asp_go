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

namespace Phwang.Fabric
{
    public class LinkMgrClass
    {
        private string objectName = "LinkMgrClass";



        public LinkMgrClass()
        {
        }

        public LinkClass MallocLink(string my_name_val)
        {
            LinkClass link = null;

            link.MyName = my_name_val;
            return link;
        }

        public void FreeLink(LinkClass link_val)
        {

        }

        public LinkClass GetLinkById(int id_val)
        {
            LinkClass link = null;

            return link;
        }

        public LinkClass GetLinkById(string my_name_val)
        {
            LinkClass link = null;

            return link;
        }

        private void debugIt(bool on_off_val, string str0_val, string str1_val)
        {
            if (on_off_val)
                this.logitIt(str0_val, str1_val);
        }

        private void logitIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangLogit(this.objectName + "." + str0_val + "()", str1_val);
        }

        private void abendIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangAbend(this.objectName + "." + str0_val + "()", str1_val);
        }
    }
}
