using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Phwang.FrontEnd
{

    public class FrontEndGoServiceClass
    {
        private string objectName = "FrontEndGoServiceClass";

        private FrontEndRootClass frontEndRootObject { get; }
        private int globalAjaxId { get; set; }

        public FrontEndGoServiceClass(FrontEndRootClass root_object_val)
        {
            this.frontEndRootObject = root_object_val;
            //this.theNetClientObject = require("../util_modules/net_client.js").malloc(this.rootObject());
            this.setupConnectionToFabric("127.0.0.1", Fabric.PortProtocolClass.LINK_MGR_PROTOCOL_TRANSPORT_PORT_NUMBER);
            this.globalAjaxId = 0;
            //this.theMaxAjaxIdIndex = 0;
            //this.theAjaxIdArray = [];
            //this.setMaxGlobalAjaxId(this.ajaxIdSize());
        }

        private void setupConnectionToFabric(string ip_addr_var, short port_var)
        {
            TcpClient client = new TcpClient(ip_addr_var, port_var);
            this.debugIt(true, "setupConnectionToFabric", "connected**************");
            NetworkStream stream = client.GetStream();
            //Utils.DebugClass.DebugIt("TcpClient", "end");

            PhwangUtils.TcpServerClass.TcpTransmitData(stream, "hello there****************");

        }

        private class AjaxEntryClass
        {
            private AjaxEntryClass()
            {
                //this.theAjaxId = ajax_id_val;
                //this.theCallbackFunction = callback_func_val;
                //this.theAjaxRequest = go_request_val;
                //this.theAjaxResponse = res_val;
            }
        }

        private AjaxEntryClass MallocAjaxEntryObject(/*callback_func_val, go_request_val, res_val*/)
        {
            this.globalAjaxId++;
            //var ajax_id_str = this.encodeNumber(this.globalAjaxId(), this.ajaxIdSize());
            //var ajax_entry_object = new AjaxEntryClass(ajax_id_str, callback_func_val, go_request_val, res_val);
            //return ajax_entry_object;
            return null;
        }

        private void debugIt(bool on_off_val, string str0_val, string str1_val)
        {
            if (on_off_val)
                this.logitIt(str0_val, str1_val);
        }

        private void logitIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangLogit(this.objectName + "::" + str0_val, str1_val);
        }

        private void abendIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangAbend(this.objectName + "::" + str0_val, str1_val);
        }

    }
}
