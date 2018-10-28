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

    public static class GroupProtocolClass
    {
        //#define GROUP_MGR_DATA_BUFFER_SIZE 512

        public const int GROUP_MGR_PROTOCOL_GROUP_ID_SIZE = 4;
        public const int GROUP_MGR_PROTOCOL_GROUP_INDEX_SIZE = 4;
        public const int GROUP_MGR_PROTOCOL_GROUP_ID_INDEX_SIZE = (GROUP_MGR_PROTOCOL_GROUP_ID_SIZE + GROUP_MGR_PROTOCOL_GROUP_INDEX_SIZE);

    }

    public static class PortProtocolClass
    {
        //#define GROUP_ROOM_PROTOCOL_TRANSPORT_PORT_NUMBER 8009
        //#define BASE_MGR_PROTOCOL_TRANSPORT_PORT_NUMBER 8005
        //#define BASE_MGR_PROTOCOL_TRANSPORT_PORT_NUMBER1 8007

    }

    public class FabricRootClass
    {
        private string objectName = "FabricRootClass";

        private UFabricClass UFabricObject { get; }
        private DFabricClass DFabricObject { get; }
        private LinkMgrClass linkMgrObject { get; }

        public LinkMgrClass LinkMgrObject() { return this.linkMgrObject; }

        //private PhwangUtils.ListMgrClass linkListMgrObject { get; }
        //private PhwangUtils.ListMgrClass groupListMgrObject { get; }

        public FabricRootClass()
        {
            this.debugIt(true, "FabricRootClass", "init start");
            this.UFabricObject = new UFabricClass(this);
            this.DFabricObject = new DFabricClass(this);
            this.linkMgrObject = new LinkMgrClass(this);
            //this->theNameListObject = new NameListClass(this);
            //this.linkListMgrObject = new PhwangUtils.ListMgrClass("LINK", FabricFrontEnd.FabricFrontEndProtocolClass.LINK_MGR_PROTOCOL_LINK_ID_SIZE, FabricFrontEnd.FabricFrontEndProtocolClass.LINK_MGR_PROTOCOL_LINK_INDEX_SIZE, 100);
            //this.groupListMgrObject = new PhwangUtils.ListMgrClass("GROUP", GroupProtocolClass.GROUP_MGR_PROTOCOL_GROUP_ID_SIZE, GroupProtocolClass.GROUP_MGR_PROTOCOL_GROUP_INDEX_SIZE, 500);
            this.StartWatchDogThread();

            this.debugIt(true, "FabricRootClass", "init done");
        }

        private void StartWatchDogThread()
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
