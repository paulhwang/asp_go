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

namespace Phwang.Engine
{
    public class DEngineParserClass
    {
        private string objectName = "DEngineParserClass";

        private DEngineClass dEngineObject;

        public DEngineParserClass(DEngineClass d_engine_object_val)
        {
            this.dEngineObject = d_engine_object_val;
        }

        public void ParseInputPacket(string input_data_val)
        {
            this.debugIt(true, "ParseInputPacket", "data=" + input_data_val);

            string command = input_data_val.Substring(0, 1);
            string input_data = input_data_val.Substring(1);


            if (command == Protocols.ThemeEngineProtocolClass.THEME_ENGINE_PROTOCOL_COMMAND_IS_SETUP_BASE)
            {
                this.processSetupBase(input_data);
                return;
            }

            if (command == Protocols.ThemeEngineProtocolClass.THEME_ENGINE_PROTOCOL_COMMAND_IS_PUT_BASE_DATA)
            {
                this.processPutBaseData(input_data);
                return;
            }

            this.abendIt("ParseInputPacket", input_data_val);
        }

        private void processSetupBase(string input_data_val)
        {
            this.debugIt(true, "processSetupBase", "data=" + input_data_val);

        }
        private void processPutBaseData(string input_data_val)
        {
            this.debugIt(true, "processPutBaseData", "data=" + input_data_val);

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
