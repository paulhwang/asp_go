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

namespace Phwang.Theme
{
    public class DThemeParserClass
    {
        private string objectName = "DThemeParserClass";

        private DThemeClass dThemeObject { get; }

        public DThemeParserClass(DThemeClass d_theme_object_val)
        {
            this.dThemeObject = d_theme_object_val;
        }

        public void ParseInputPacket(string data_val)
        {
            this.debugIt(true, "ParseInputPacket", data_val);
            string command = data_val.Substring(0, 1);
            string data = data_val.Substring(1);

            if (command == Protocols.FabricThemeProtocolClass.FABRIC_THEME_PROTOCOL_COMMAND_IS_SETUP_ROOM)
            {
                this.processSetupRoom(data);
                return;
            }

            if (command == Protocols.FabricThemeProtocolClass.FABRIC_THEME_PROTOCOL_COMMAND_IS_PUT_ROOM_DATA)
            {
                this.processPutRoomData(data);
                return;
            }

            this.abendIt("ParseInputPacket", data_val);

        }

        private void processSetupRoom(string data_val)
        {

        }

        private void processPutRoomData(string data_val)
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
