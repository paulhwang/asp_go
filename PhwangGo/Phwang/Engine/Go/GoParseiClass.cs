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

namespace Phwang.Go
{
    public class GoParseClass
    {
        private string objectName = "GoParseClass";

        private GoRootClass rootObject { get; }

        public GoGameClass GameObject() { return this.rootObject.GameObject(); }


    public GoParseClass(GoRootClass go_root_object_val)
        {
            this.rootObject = go_root_object_val;
        }

        //#define GO_PROTOCOL_GAME_INFO 'G'
        //#define GO_PROTOCOL_TIME_INFO 'T'
        //#define GO_PROTOCOL_CHAT_INFO 'C'
        private const char GO_PROTOCOL_MOVE_COMMAND = 'M';
        //#define GO_PROTOCOL_PASS_COMMAND 'P'
        //#define GO_PROTOCOL_BACKWARD_COMMAND 'b'
        //#define GO_PROTOCOL_DOUBLE_BACKWARD_COMMAND 'B'
        //#define GO_PROTOCOL_FORWARD_COMMAND 'f'
        //#define GO_PROTOCOL_DOUBLE_FORWARD_COMMAND 'F'
        //#define GO_PROTOCOL_RESIGN_COMMAND 'R'
        //#define GO_PROTOCOL_CONFIRM_COMMAND 'C'
        //#define GO_PROTOCOL_CONTINUE_COMMAND 'c'

        public string ParseInputData(string input_data_val)
        {
            int len = input_data_val.Length;//to be deleted
            switch (input_data_val[0])
            {
                case GO_PROTOCOL_MOVE_COMMAND:
                    GoMoveClass move = new GoMoveClass(input_data_val.Substring(1, 8));
                    return this.GameObject().AddNewMoveAndFight(move);

                default:
                    string err_msg = "command " + input_data_val[1] + " not supported";
                    this.abendIt("ParseInputData", err_msg);
                    return err_msg;
            }
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
