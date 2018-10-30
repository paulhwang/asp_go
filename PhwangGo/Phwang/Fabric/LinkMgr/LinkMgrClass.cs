﻿/*
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

        private FabricRootClass fabricRootObject { get; }
        private PhwangUtils.ListMgrClass listMgr { get; }

        public PhwangUtils.ListMgrClass ListMgr() { return this.listMgr; }
        private NameListClass nameListObject() { return this.fabricRootObject.NameListObject(); }

        public LinkMgrClass(FabricRootClass root_fabric_object_val)
        {
            this.fabricRootObject = root_fabric_object_val;
            this.listMgr = new PhwangUtils.ListMgrClass(this.objectName, 1000);
        }

        public LinkClass MallocLink(string my_name_val)
        {
            LinkClass link = new LinkClass(my_name_val);
            PhwangUtils.ListEntryClass list_entry = this.listMgr.MallocEntry(link);
            link.BindListEntry(list_entry);
            this.nameListObject().UpdateNameList();
            return link;
        }

        public void FreeLink(LinkClass link_val)
        {

        }

        public LinkClass GetLinkById(int id_val)
        {
            PhwangUtils.ListEntryClass list_entry = this.listMgr.GetEntryById(id_val);
            if (list_entry == null)
            {
                return null;
            }
            LinkClass link = (LinkClass) list_entry.Data;

            return link;
        }

        public LinkClass GetLinkByMyName(string my_name_val)
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
