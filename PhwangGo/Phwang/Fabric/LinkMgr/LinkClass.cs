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
    public class LinkClass
    {
        private string objectName = "LinkClass";

        private PhwangUtils.ListEntryClass listEntryObject;
        public int LinkId { get; set; }
        public string LinkIdStr { get; set; }
        public string MyName { get; set; }
        private SessionMgrClass sessionMgrObject { get; }

        public LinkClass(string my_name_val)
        {
            this.MyName = my_name_val;

            this.sessionMgrObject = new SessionMgrClass(this);
        }

        public void BindListEntry(PhwangUtils.ListEntryClass list_entry_objectg_val)
        {
            this.listEntryObject = list_entry_objectg_val;
            this.LinkId = this.listEntryObject.Id;
            this.LinkIdStr = PhwangUtils.EncodeNumberClass.EncodeNumber(this.LinkId, FabricFrontEnd.FabricFrontEndProtocolClass.LINK_MGR_PROTOCOL_LINK_ID_SIZE);
        }

        public SessionClass MallocSession()
        {
            return this.sessionMgrObject.MallocSession();
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
