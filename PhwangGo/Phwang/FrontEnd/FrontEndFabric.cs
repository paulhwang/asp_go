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
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Phwang.FrontEnd
{

    public class FrontEndFabricClass
    {
        private string objectName = "FrontEndFabricClass";

        private FrontEndRootClass frontEndRootObject { get; }
        private PhwangUtils.BinderClass binderObject { get; }
        private int globalAjaxId { get; set; }

        public FrontEndFabricClass(FrontEndRootClass root_object_val)
        {
            this.debugIt(true, "FrontEndFabricClass", "init start");
            this.frontEndRootObject = root_object_val;
            this.binderObject = new PhwangUtils.BinderClass(this.objectName);
            this.binderObject.BindAsTcpClient("127.0.0.1", FabricFrontEnd.FabricFrontEndProtocolClass.LINK_MGR_PROTOCOL_TRANSPORT_PORT_NUMBER);

            //this.theNetClientObject = require("../util_modules/net_client.js").malloc(this.rootObject());
            this.globalAjaxId = 0;
            //this.theMaxAjaxIdIndex = 0;
            //this.theAjaxIdArray = [];
            //this.setMaxGlobalAjaxId(this.ajaxIdSize());
            this.debugIt(true, "FrontEndFabricClass", "init done");
        }

        public void transmitDataToFabric(string data_var)
        {
            this.binderObject.TransmitData(data_var);
            /*
            this.putAjaxEntryObject(ajax_entry_object_val);
            if (data_val.length < 1000)
            {
                this.netClientOjbect().write("{" + this.encodeNumber(data_val.length, 3) + data_val + "}");
            }
            else
            {
                this.netClientOjbect().write("[" + this.encodeNumber(data_val.length, 5) + data_val + "]");
            }
*/
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
            PhwangUtils.AbendClass.phwangLogit(this.objectName + "." + str0_val + "()", str1_val);
        }

        private void abendIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangAbend(this.objectName + "." + str0_val + "()", str1_val);
        }
    }
}
