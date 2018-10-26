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
        private int ajaxIdSize = 3;

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
            AjaxEntryClass ajax_entry_object = this.mallocAjaxEntryObject();
            this.binderObject.TransmitData(data_var);
        }

        public string receiveDataFromFabric()
        {
            return this.binderObject.ReceiveData();
        }

        private class AjaxEntryClass
        {
            private string ajaxIdStr { get; }

            public AjaxEntryClass(string ajax_id_str_val)
            {
                this.ajaxIdStr = ajax_id_str_val;
            }
        }

        private AjaxEntryClass mallocAjaxEntryObject()
        {
            this.globalAjaxId++;
            string ajax_id_str = this.EncodeNumber(this.globalAjaxId, this.ajaxIdSize);
            this.debugIt(true, "MallocAjaxEntryObject", "********data={" + ajax_id_str + "}");
            AjaxEntryClass ajax_entry_object = new AjaxEntryClass(ajax_id_str);
            return ajax_entry_object;
        }
        
        public string EncodeNumber(int number_val, int size_val)
        {
            string str = number_val.ToString();

            var buf = "";
            for (var i = str.Length; i < size_val; i++)
            {
                buf = buf + "0";
            }
            buf = buf + str;
            return buf;
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
