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
            
        private GoRootClass goRootObject { get; }

    public GoParseClass(GoRootClass go_root_object_val)
        {
            this.goRootObject = go_root_object_val;
        }
        public string ParseInputData(string input_data_val)
        {
            int len = input_data_val.Length;//tob
            switch (input_data_val[0])
            {
                case 'M':
                    int x = (input_data_val[1] - '0') * 10 + (input_data_val[2] - '0');
                    int y = (input_data_val[3] - '0') * 10 + (input_data_val[4] - '0');
                    int color = input_data_val[5] - '0';
                    int turn_index = (input_data_val[6] - '0') * 100 + (input_data_val[7] - '0') * 10 + (input_data_val[8] - '0');
                    int turn_index1 = PhwangUtils.EncodeNumberClass.DecodeNumber(input_data_val.Substring(6, 3));
                    return "GO TBD";

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
