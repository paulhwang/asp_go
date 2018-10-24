using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.PhwangUtils
{
    public class TpServerClass
    {
        private string ObjectName = "TpServerClass";

        private object callerObject { get; }
        private short thePort { get; }
        private string theWho { get; }

        //void (* theAcceptCallbackFunc) (void*, void*);
        //void (* theReceiveCallbackFunc) (void*, void*, void*);
        //void* theAcceptCallbackParameter;
        //  void* theReceiveCallbackParameter;
        //pthread_t theServerThread;
        int tpTransferObjectIndex { get; }

        public TpServerClass(
                    Object caller_object_val,
                    short port_val/*,
                    void (* accept_callback_func_val) (void*, void*),
                    void* accept_callback_parameter_val,
                    void (* receive_callback_func_val) (void*, void*, void*),
                    void* receive_callback_parameter_val*/,
                    string who_val)

        {
            this.callerObject = caller_object_val;
            this.thePort = port_val;
            //this->theAcceptCallbackFunc = accept_callback_func_val;
            //this->theReceiveCallbackFunc = receive_callback_func_val;
            //this->theAcceptCallbackParameter = accept_callback_parameter_val;
            //this->theReceiveCallbackParameter = receive_callback_parameter_val;
            this.theWho = who_val;
            this.tpTransferObjectIndex = 1;

            this.debug(true, who_val, "TpServerClass");
            //this.debug(true, "TpServerClass", "init");
        }
 
        public void StartServerThread()
        {
            this.debug(false, "startServerThread", "");
 
            /*
            int r = pthread_create(&this->theServerThread, 0, transportServerThreadFunction, this);
            if (r)
            {
                printf("Error - startServerThread() return code: %d\n", r);
                return;
            }
            */
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
