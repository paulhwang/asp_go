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
    public class UFabricClass
    {
        private string objectName = "UFabricClass";

        private FabricRootClass FabricRootObject { get; }
        //void* theTpServerObject;
        //void* theTpTransferObject;

        public UFabricClass(FabricRootClass fabric_root_class_val)
        {
            this.debugIt(true, "UFabricClass", "init start");
            this.FabricRootObject = fabric_root_class_val;
            this.StartNetServer();
            this.debugIt(true, "UFabricClass", "init done");
        }

        void StartNetServer()
        {
            //this.TpServerObject = phwangMallocTpServer(this, GROUP_ROOM_PROTOCOL_TRANSPORT_PORT_NUMBER, uFabricTpServerAcceptFunction, this, uFabricTpReceiveDataFunction, this, this->objectName());
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
