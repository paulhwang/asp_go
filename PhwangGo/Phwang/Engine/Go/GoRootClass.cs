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
    public class GoRootClass
    {
        private string objectName = "GoRootClass";

        private GoApiClass apiObject { get; }
        private GoConfigClass goConfigObject { get; }


        public GoRootClass()
        {
            this.goConfigObject = new GoConfigClass(this);
        }

        public string DoSetup(string input_data_val)
        {
            this.goConfigObject.ConfigIt(input_data_val);
            return null;
        }

        public string ProcessInputData(string input_data_val)
        {
            return "GO TBD";
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
