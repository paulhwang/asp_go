using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Phwang.FrontEnd
{
    public class FrontEndAjaxMapClass
    {
        public string ajaxIdStr { get; }
        private ManualResetEvent theSignal { get; }

        public FrontEndAjaxMapClass(string ajax_id_str_val)
        {
            this.ajaxIdStr = ajax_id_str_val;
            this.theSignal = new ManualResetEvent(false);
        }

        public void PendingTillWorkDone()
        {
            this.theSignal.WaitOne();
        }

        public void WakeUpPendingThread()
        {
            this.theSignal.Set();
        }
    }
}
