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
        private int linkId { get; set; }
        private string myName { get; }
        private SessionMgrClass sessionMgrObject { get; }

        public string MyName() { return this.myName; }
        public int LinkId() { return this.linkId; }
        public string LinkIdStr { get; set; }

        public LinkClass(string my_name_val)
        {
            this.myName = my_name_val;

            this.sessionMgrObject = new SessionMgrClass(this);
        }

        public void BindListEntry(PhwangUtils.ListEntryClass list_entry_objectg_val)
        {
            this.listEntryObject = list_entry_objectg_val;
            this.linkId = this.listEntryObject.Id;
            this.LinkIdStr = PhwangUtils.EncodeNumberClass.EncodeNumber(this.linkId, Protocols.FabricFrontEndProtocolClass.LINK_MGR_PROTOCOL_LINK_ID_SIZE);
        }

        public SessionClass MallocSession()
        {
            return this.sessionMgrObject.MallocSession();
        }

        public void SetPendingSessionSetup3(string session_id_str_val, string aaa)
        {

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
