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
    public class GroupClass
    {
        private string objectName = "GroupClass";
        private const int GROUP_MGR_PROTOCOL_GROUP_ID_SIZE = 4;

        private PhwangUtils.ListEntryClass listEntryObject;
        private int groupId { get; set; }
        private string themeData { get; }
        private GroupSessionMgrClass groupSessionMgrObject { get; }

        public string ThemeData() { return this.themeData; }
        public int GroupId() { return this.groupId; }
        public string GroupIdStr { get; set; }

        public GroupClass(string theme_data_val)
        {
            this.themeData = theme_data_val;
            this.groupSessionMgrObject = new GroupSessionMgrClass();

        }

        public void BindListEntry(PhwangUtils.ListEntryClass list_entry_objectg_val)
        {
            this.listEntryObject = list_entry_objectg_val;
            this.groupId = this.listEntryObject.Id;
            this.GroupIdStr = PhwangUtils.EncodeNumberClass.EncodeNumber(this.groupId, GROUP_MGR_PROTOCOL_GROUP_ID_SIZE);
        }

        public void InsertSession(SessionClass session_val)
        {

        }
        public void RemoveSession(SessionClass session_val)
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
