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
    public class UFabricParserClass
    {
        private string objectName = "UFabricParserClass";

        private UFabricClass uFabricObject { get; }

        public FabricRootClass FabricRootObject() { return this.uFabricObject.FabricRootObject();}
        public GroupMgrClass GroupMgrObject() { return this.FabricRootObject().GroupMgrObject(); }

        public UFabricParserClass(UFabricClass ufabric_object_val)
        {
            this.uFabricObject = ufabric_object_val;
        }

        public void parseInputPacket(string input_data_val)
        {
            this.debugIt(true, "exportedParseFunction", input_data_val);
            string command = input_data_val.Substring(0, 1);
            string input_data = input_data_val.Substring(1);

            if (command == Protocols.FabricThemeProtocolClass.FABRIC_THEME_PROTOCOL_RESPOND_IS_SETUP_ROOM)
            {
                this.processSetupRoomResponse(input_data);
                return;
            }

            if (command == Protocols.FabricThemeProtocolClass.FABRIC_THEME_PROTOCOL_RESPOND_IS_PUT_ROOM_DATA)
            {
                this.processPutRoomDataResponse(input_data);
                return;
            }

            this.abendIt("exportedParseFunction", input_data_val);
        }
        private void processSetupRoomResponse(string input_data_val)
        {
            string group_id_str = input_data_val.Substring(0, Protocols.FabricThemeProtocolClass.GROUP_MGR_PROTOCOL_GROUP_ID_STR_SIZE);
            string room_id_str = input_data_val.Substring(Protocols.FabricThemeProtocolClass.GROUP_MGR_PROTOCOL_GROUP_ID_STR_SIZE);

            GroupClass group = this.GroupMgrObject().GetGroupByGroupIdStr(group_id_str);
            if (group != null)
            {
                group.SetRoomIdStr(room_id_str);
                //group->setSessionTableArray((SessionClass**)phwangArrayMgrGetArrayTable(group->sessionArrayMgr(), &session_array_size));
                //printf("++++++++++++++++++++++++++++++++++++++++++++%d\n", session_array_size);
                //for (int i = 0; i < session_array_size; i++)
                //{
                    //SessionClass* session = group->sessionTableArray(0);
                    //session->linkObject()->setPendingSessionSetup3(session->sessionIdIndex(), "");
                //}
            }
        }
        private void processPutRoomDataResponse(string input_data_val)
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
