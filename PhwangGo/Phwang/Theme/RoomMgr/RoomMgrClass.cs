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

namespace Phwang.Theme
{
    public class RoomMgrClass
    {
        private string objectName = "RoomMgrClass";
        private const int FIRST_ROOM_ID = 7000;

        private ThemeRootClass themeRootObject { get; }
        private PhwangUtils.ListMgrClass listMgr { get; }

        public RoomMgrClass(ThemeRootClass theme_root_object_val)
        {
            this.themeRootObject = theme_root_object_val;
            this.listMgr = new PhwangUtils.ListMgrClass(this.objectName, FIRST_ROOM_ID);
        }
        public RoomClass MallocRoom(string room_id_index_val)
        {
            RoomClass room = new RoomClass(room_id_index_val);
            PhwangUtils.ListEntryClass list_entry = this.listMgr.MallocEntry(room);
            room.BindListEntry(list_entry);
            return room;
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
