/*
 ******************************************************************************
 *                                       
 *  Copyright (c) 2018 phwang. All rights reserved.
 *
 ******************************************************************************
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Phwang.Fabric
{
    public class DFabricParserClass
    {
        private string objectName = "DFabricParserClass";
        private string RESPONSE_IS_GET_LINK_DATA_NAME_LIST = Protocols.FabricFrontEndProtocolClass.WEB_FABRIC_PROTOCOL_RESPOND_IS_GET_LINK_DATA_NAME_LIST;

        private DFabricClass dFabricObject { get; }
        private DFabricResponseClass dFabricResponseObject { get; }

        public FabricRootClass FabricRootObject() { return this.dFabricObject.FabricRootObject(); }
        private LinkMgrClass LinkMgrObject() { return this.FabricRootObject().LinkMgrObject(); }
        private GroupMgrClass GroupMgrObject() { return this.FabricRootObject().GroupMgrObject(); }

        public DFabricParserClass(DFabricClass dfabric_object_val)
        {
            this.dFabricObject = dfabric_object_val;
            this.dFabricResponseObject = new DFabricResponseClass(this);
        }

        [DataContract]
        public class AjaxFabricRequestFormatClass
        {
            [DataMember]
            public string command { get; set; }

            [DataMember]
            public int packet_id { get; set; }

            [DataMember]
            public string data { get; set; }
        }

        public void parseInputPacket(string input_data_var)
        {
            string adax_id = input_data_var.Substring(0, Protocols.FabricFrontEndProtocolClass.AJAX_MAPING_ID_SIZE);
            string toDes = input_data_var.Substring(Protocols.FabricFrontEndProtocolClass.AJAX_MAPING_ID_SIZE);
            AjaxFabricRequestFormatClass ajax_fabric_request;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(toDes)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(AjaxFabricRequestFormatClass));
                ajax_fabric_request = (AjaxFabricRequestFormatClass)deseralizer.ReadObject(ms);
                this.debugIt(true, "ParseAjaxPacket", "input_data_var = " + input_data_var);
                this.debugIt(true, "ParseAjaxPacket", "command = " + ajax_fabric_request.command);
                this.debugIt(true, "ParseAjaxPacket", "data = " + ajax_fabric_request.data);
            }

            string response_data;
            if (ajax_fabric_request.command == "setup_link")
            {
                response_data = this.processSetupLinkRequest(ajax_fabric_request.data);
            }
            else if (ajax_fabric_request.command == "get_link_data")
            {
                response_data = this.processGetLinkDataRequest(ajax_fabric_request.data);
            }
            else if (ajax_fabric_request.command == "get_name_list")
            {
                response_data = this.processGetNameListRequest(ajax_fabric_request.data);
            }
            else if (ajax_fabric_request.command == "setup_session")
            {
                response_data = this.processSetupSessionRequest(ajax_fabric_request.data);
            }
            else
            {
                response_data = "command " + ajax_fabric_request.command + " not supported";
            }
            this.dFabricObject.TransmitData(adax_id + response_data);
        }

        [DataContract]
        public class SetupLinkRequestFormatClass
        {
            [DataMember]
            public string my_name { get; set; }

            [DataMember]
            public string password { get; set; }
        }

        private string processSetupLinkRequest(string input_data_var)
        {
            this.debugIt(true, "processSetupLinkRequest", "input_data_var = " + input_data_var);
            SetupLinkRequestFormatClass format_data;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(input_data_var)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(SetupLinkRequestFormatClass));
                format_data = (SetupLinkRequestFormatClass)deseralizer.ReadObject(ms);// //反序列化ReadObject
                this.debugIt(true, "processSetupLinkRequest", "my_name = " + format_data.my_name);
                this.debugIt(true, "processSetupLinkRequest", "password = " + format_data.password);
            }

            LinkClass link = this.LinkMgrObject().MallocLink(format_data.my_name);
            string response_data = this.dFabricResponseObject.GenerateSetupLinkResponse(link.LinkId(), link.MyName());
            return response_data;
        }

        [DataContract]
        public class GetLinkDataRequestFormat
        {
            [DataMember]
            public int link_id { get; set; }
        }

        private string processGetLinkDataRequest(string input_data_var)
        {
            this.debugIt(true, "processGetLinkDataRequest", "input_data_var = " + input_data_var);
            GetLinkDataRequestFormat format_data;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(input_data_var)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(GetLinkDataRequestFormat));
                format_data = (GetLinkDataRequestFormat)deseralizer.ReadObject(ms);// //反序列化ReadObject
                this.debugIt(true, "processGetLinkDataRequest", "link_id = " + format_data.link_id);
            }

            LinkClass link = this.LinkMgrObject().GetLinkById(format_data.link_id);

            string data = RESPONSE_IS_GET_LINK_DATA_NAME_LIST + this.FabricRootObject().NameListObject().NameListTagStr();

            string response_data = this.dFabricResponseObject.GenerateGetLinkDataResponse(link.LinkIdStr, data);
            return response_data;
        }

        [DataContract]
        public class GetNameListRequestFormat
        {
            [DataMember]
            public int link_id { get; set; }
            public int name_list_tag { get; set; }
        }

        private string processGetNameListRequest(string input_data_var)
        {
            this.debugIt(true, "processGetNameListRequest", "input_data_var = " + input_data_var);
            GetNameListRequestFormat format_data;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(input_data_var)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(GetNameListRequestFormat));
                format_data = (GetNameListRequestFormat)deseralizer.ReadObject(ms);// //反序列化ReadObject
                this.debugIt(true, "processGetNameListRequest", "link_id = " + format_data.link_id);
            }

            LinkClass link = this.LinkMgrObject().GetLinkById(format_data.link_id);

            string name_list = this.FabricRootObject().NameListObject().GetNameList(format_data.name_list_tag);

            string response_data = this.dFabricResponseObject.GenerateGetNameListResponse(link.LinkIdStr, name_list);
            return response_data;
        }

        [DataContract]
        public class SetupSessionRequestFormat
        {
            [DataMember]
            public int link_id { get; set; }

            [DataMember]
            public string his_name { get; set; }

            [DataMember]
            public string theme_data { get; set; }
        }

        private string processSetupSessionRequest(string input_data_var)
        {
            this.debugIt(true, "processSetupSessionRequest", "input_data_var = " + input_data_var);
            SetupSessionRequestFormat format_data;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(input_data_var)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(SetupSessionRequestFormat));
                format_data = (SetupSessionRequestFormat)deseralizer.ReadObject(ms);// //反序列化ReadObject
                this.debugIt(true, "processGetLinkDataRequest", "link_id = " + format_data.link_id);
                this.debugIt(true, "processGetLinkDataRequest", "his_name = " + format_data.his_name);
                this.debugIt(true, "processGetLinkDataRequest", "theme_data = " + format_data.theme_data);
            }

            LinkClass link = this.LinkMgrObject().GetLinkById(format_data.link_id);
            SessionClass session = link.MallocSession();
            GroupClass group = this.GroupMgrObject().MallocGroup(format_data.theme_data);
            if (group == null)
            {
                return this.errorProcessSetupSession(format_data.link_id, "null group");
            }
            group.InsertSession(session);
            session.BindGroup(group);

            if (format_data.his_name == link.MyName())
            {
                this.mallocRoom(group, format_data.theme_data);
            }
            /*
            else
            {
                LinkClass his_link = this.LinkMgrObject().SearchLinkByName(his_name_val);
                if (!his_link)
                {
                    this->errorProcessSetupSession(tp_transfer_object_val, ajax_id, "his_link does not exist");
                    return;
                }

                SessionClass* his_session = his_link->mallocSession();
                if (!his_session)
                {
                    this->errorProcessSetupSession(tp_transfer_object_val, ajax_id, "null his_session");
                    return;
                }

                group->insertSession(his_session);
                his_session->bindGroup(group);

                char* theme_data = (char*)malloc(32);
                memcpy(theme_data, theme_info_val, theme_len);
                theme_data[theme_len] = 0;
                his_link->setPendingSessionSetup(his_session->sessionIdIndex(), theme_data);
            }
            */
            //char* data_ptr;
            //char* downlink_data = data_ptr = (char*)phwangMalloc(LINK_MGR_DATA_BUFFER_SIZE + 4, "DFS1");
            //*data_ptr++ = WEB_FABRIC_PROTOCOL_RESPOND_IS_SETUP_SESSION;
            //memcpy(data_ptr, ajax_id, WEB_FABRIC_PROTOCOL_AJAX_ID_SIZE);
            //data_ptr += WEB_FABRIC_PROTOCOL_AJAX_ID_SIZE;
            //strcpy(data_ptr, session->sessionIdIndex());
            //this->transmitFunction(tp_transfer_object_val, downlink_data);

            string response_data = this.dFabricResponseObject.GenerateSetupSessionResponse(link.LinkIdStr, session.SessionIdStr());
            return response_data;
        }

        private string errorProcessSetupSession(int link_id_val, string error_msg_val)
        {
            return error_msg_val;
        }

        private void mallocRoom(GroupClass group_val, string theme_info_val)
        {
            string uplink_data = Protocols.FabricThemeProtocolClass.FABRIC_THEME_PROTOCOL_COMMAND_IS_SETUP_ROOM;
            uplink_data = uplink_data + group_val.GroupIdStr();
            uplink_data = uplink_data + theme_info_val;
            this.FabricRootObject().UFabricObject().TransmitData(uplink_data);

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
