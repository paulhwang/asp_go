using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.PhwangUtils
{
    public class TpTransferClass
    {
        private string ObjectName = "TpTransferClass";

        public TpTransferClass()
        {

        }

        private void debug(bool on_off_val, string str0_val, string str1_val)
        {
            if (on_off_val)
                this.logit(str0_val, str1_val);
        }

        private void logit(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangLogit(this.ObjectName + "::" + str0_val, str1_val);
        }

        private void abend(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangAbend(this.ObjectName + "::" + str0_val, str1_val);
        }
    }
}
