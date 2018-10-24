using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.PhwangUtils
{
    public class TpApiClass
    {
        public static TpServerClass MallocTpServer(/*void* caller_object_val,
                                unsigned short port_val,
                                void (* accept_callback_func_val)(void*, void*),
                                void* accept_callback_parameter_val,
                                void (* receive_callback_func_val)(void*, void*, void*),
                                void* receive_callback_parameter_val,
                                char const * who_val*/)
        {
            TpServerClass tp_server_object = new TpServerClass(/*
                    caller_object_val,
                    port_val,
                    accept_callback_func_val,
                    accept_callback_parameter_val,
                    receive_callback_func_val,
                    receive_callback_parameter_val,
                    who_val*/);

            if (tp_server_object != null) {
                tp_server_object.StartServerThread();
            }
            return tp_server_object;
        }
    }
}
