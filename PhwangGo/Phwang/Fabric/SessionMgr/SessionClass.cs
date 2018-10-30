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
    public class SessionClass
    {
        private string objectName = "SessionClass";

        private PhwangUtils.ListEntryClass listEntryObject;
        public int sessionId { get; set; }

        public int SessionId() { return this.sessionId; }
        public string SessionIdStr { get; set; }

        public SessionClass()
        {
        }

        public void BindListEntry(PhwangUtils.ListEntryClass list_entry_objectg_val)
        {
            this.listEntryObject = list_entry_objectg_val;
            this.sessionId = this.listEntryObject.Id;
            this.SessionIdStr = PhwangUtils.EncodeNumberClass.EncodeNumber(this.sessionId, FabricFrontEnd.FabricFrontEndProtocolClass.LINK_MGR_PROTOCOL_SESSION_ID_SIZE);
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
