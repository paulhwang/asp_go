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
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Phwang.FrontEnd
{


    public class FrontEndFabricClass
    {
        private string objectName = "FrontEndFabricClass";
        private const int MAX_AJAX_ENTRY_ARRAY_SIZE = 1000;

        private FrontEndRootClass frontEndRootObject { get; }
        private PhwangUtils.BinderClass binderObject { get; }
        private int nextAvailableAjaxId { get; set; }
        private int maxAllowedAjaxId { get; set; }
        private int maxAjaxMapIndex { get; set; }
        private FrontEndJobClass[] ajaxMapArray { get; }

        public FrontEndFabricClass(FrontEndRootClass root_object_val)
        {
            this.debugIt(true, "FrontEndFabricClass", "init start");
            this.frontEndRootObject = root_object_val;
            this.binderObject = new PhwangUtils.BinderClass(this.objectName);
            this.binderObject.BindAsTcpClient("127.0.0.1", FabricFrontEnd.FabricFrontEndProtocolClass.LINK_MGR_PROTOCOL_TRANSPORT_PORT_NUMBER);

            //this.theNetClientObject = require("../util_modules/net_client.js").malloc(this.rootObject());
            this.nextAvailableAjaxId = 0;
            this.maxAjaxMapIndex = 0;
            this.setMaxGlobalAjaxId(FabricFrontEnd.FabricFrontEndProtocolClass.AJAX_MAPING_ID_SIZE);
            this.ajaxMapArray = new FrontEndJobClass[MAX_AJAX_ENTRY_ARRAY_SIZE];
            this.debugIt(true, "FrontEndFabricClass", "init done");
        }

        public string receiveDataFromFabric()
        {
            string received_data = this.binderObject.ReceiveData();
            string ajax_id_str = received_data.Substring(0, FabricFrontEnd.FabricFrontEndProtocolClass.AJAX_MAPING_ID_SIZE);
            FrontEndJobClass ajax_entry = getAjaxEntryObject(ajax_id_str);
            if (ajax_entry == null)
            {
                this.abendIt("receiveDataFromFabric", "null ajax_entry");
            }
            string response_data = received_data.Substring(FabricFrontEnd.FabricFrontEndProtocolClass.AJAX_MAPING_ID_SIZE);
            return response_data;
        }

        public void transmitDataToFabric(string data_var)
        {
            FrontEndJobClass ajax_entry_object = this.mallocAjaxEntryObject();
            this.putAjaxEntryObject(ajax_entry_object);
            this.binderObject.TransmitData(ajax_entry_object.ajaxIdStr + data_var);
        }

        private void putAjaxEntryObject(FrontEndJobClass val)
        {
            for (var i = 0; i < this.maxAjaxMapIndex; i++)
            {
                if (this.ajaxMapArray[i] == null)
                {
                    this.ajaxMapArray[i] = val;
                    return;
                }
            }
            this.ajaxMapArray[this.maxAjaxMapIndex] = val;
            this.incrementMaxAjaxMapIndex();
        }

        public FrontEndJobClass getAjaxEntryObject(string ajax_id_str_val)
        {
            int index;

            var found = false;
            for (index = 0; index < this.maxAjaxMapIndex; index++)
            {
                if (this.ajaxMapArray[index] != null)
                {
                    if (this.ajaxMapArray[index].ajaxIdStr == ajax_id_str_val)
                    {
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                this.abendIt("getAjaxEntryObject", "not found" + ajax_id_str_val);
                return null;
            }

            FrontEndJobClass element = this.ajaxMapArray[index];
            this.ajaxMapArray[index] = null;
            return element;
        }

        private void incrementMaxAjaxMapIndex()
        {
            this.maxAjaxMapIndex++;
        }

        private FrontEndJobClass mallocAjaxEntryObject()
        {
            this.incrementNextAvailableAjaxId();
            string ajax_id_str = this.EncodeNumber(this.nextAvailableAjaxId, FabricFrontEnd.FabricFrontEndProtocolClass.AJAX_MAPING_ID_SIZE);
            this.debugIt(true, "MallocAjaxEntryObject", "********data={" + ajax_id_str + "}");
            FrontEndJobClass ajax_entry_object = new FrontEndJobClass(ajax_id_str);
            return ajax_entry_object;
        }

        private void incrementNextAvailableAjaxId()
        {
            this.nextAvailableAjaxId++;
            if (this.nextAvailableAjaxId > this.maxAllowedAjaxId)
            {
                this.nextAvailableAjaxId = 1;
            }
        }

        private void setMaxGlobalAjaxId (int ajax_id_size_val)
        {
            this.maxAllowedAjaxId = 1;
            for (var i = 0; i < ajax_id_size_val; i++)
            {
                this.maxAllowedAjaxId *= 10;
            }
            this.maxAllowedAjaxId -= 1;
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
