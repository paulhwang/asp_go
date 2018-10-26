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

        FabricRootClass fabricRootObject;
        //char theLinkName[LINK_CLASS_LINK_NAME_BUF_SIZE + 4];
        object theSessionListMgrObject;
        object thePendingSessionSetupQueue;
        object thePendingSessionSetupQueue3;
        private char theNameListChanged;
        //time_t theKeepAliveTime;

        public LinkClass(object list_mgr_object_val, FabricRootClass fabric_root_object_val, string link_name_val)
        {
            //this.listEntryClass = list_mgr_object_val;
            this.fabricRootObject = fabric_root_object_val;
            this.theNameListChanged = 'D';

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
