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
        private const int MAX_ROOM_LIST_SIZE = 1000;

        private ThemeRootClass themeRootObject { get; }
        private PhwangUtils.ListMgrClass listMgr { get; }

        public RoomMgrClass(ThemeRootClass theme_root_object_val)
        {
            this.themeRootObject = theme_root_object_val;
            this.listMgr = new PhwangUtils.ListMgrClass(this.objectName, MAX_ROOM_LIST_SIZE);
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
