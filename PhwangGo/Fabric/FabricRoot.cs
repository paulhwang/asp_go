using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.Fabric
{
    public static class FabricProtocalClass
    {
        //#define LINK_MGR_DATA_BUFFER_SIZE 512

        public const int LINK_MGR_PROTOCOL_LINK_ID_SIZE=  4;
        public const int LINK_MGR_PROTOCOL_LINK_INDEX_SIZE = 4;
//#define LINK_MGR_PROTOCOL_LINK_ID_INDEX_SIZE (LINK_MGR_PROTOCOL_LINK_ID_SIZE + LINK_MGR_PROTOCOL_LINK_INDEX_SIZE)

//#define LINK_MGR_PROTOCOL_SESSION_ID_SIZE 4
//#define LINK_MGR_PROTOCOL_SESSION_INDEX_SIZE 4
//#define LINK_MGR_PROTOCOL_SESSION_ID_INDEX_SIZE (LINK_MGR_PROTOCOL_SESSION_ID_SIZE + LINK_MGR_PROTOCOL_SESSION_INDEX_SIZE)
    }

    public class FabricRootClass
    {
        private string ObjectName = "FabricRootClass";

        private UFabricClass UFabricObject { get; }
        private DFabricClass DFabricObject { get; }
        private PhwangUtils.ListMgrClass ListMgrObject { get; }

        public FabricRootClass()
        {
            this.UFabricObject = new UFabricClass(this);
            this.DFabricObject = new DFabricClass(this);
            //this->theNameListObject = new NameListClass(this);
            this.ListMgrObject = new PhwangUtils.ListMgrClass("LINK", FabricProtocalClass.LINK_MGR_PROTOCOL_LINK_ID_SIZE, FabricProtocalClass.LINK_MGR_PROTOCOL_LINK_INDEX_SIZE, 100);
            //this->theGroupListMgrObject = phwangListMgrMalloc("GROUP", GROUP_MGR_PROTOCOL_GROUP_ID_SIZE, GROUP_MGR_PROTOCOL_GROUP_INDEX_SIZE, 500);
            //this->startWatchDogThread();

            this.debug(true, "FabricRootClass", "init");
        }

        private void debug(bool on_off_val, string str0_val, string str1_val)
        {
            if (on_off_val)
                this.logit(str0_val, str1_val);
        }

        private void logit(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangLogit(this.ObjectName + "::" + str0_val, str1_val);
        }

        private void abend(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangAbend(this.ObjectName + "::" + str0_val, str1_val);
        }
    }
}
