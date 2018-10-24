using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.PhwangUtils.ListMgr
{
    public class ListMgrClass
    {
        private int LIST_MGR_ID_INDEX_ARRAY_SIZE { get; }
        private int LIST_MGR_MAX_GLOBAL_LIST_ID { get; }
        private string ObjectName { get; }
        //char const * theCallerName;
        //int theIdSize;
        //int theIndexSize;
        //int theIdIndexSize;
        private int GlobalEntryId { get; set; }
        //int theMaxIdIndexTableIndex;
        //int theMaxIndex;
        //int theEntryCount;
        private ListEntryClass[] EntryTableArray;
        //pthread_mutex_t theMutex;

        public ListMgrClass()
        {
            this.LIST_MGR_MAX_GLOBAL_LIST_ID = 9999;
            this.LIST_MGR_ID_INDEX_ARRAY_SIZE = 1000;
            this.ObjectName = "ListMgrClass";

            //if (pthread_mutex_init(&this->theMutex, NULL) != 0)
            {
                //this->abend("ListMgrClass", "pthread_mutex_init fail");
            }


            this.EntryTableArray = new ListEntryClass[this.LIST_MGR_ID_INDEX_ARRAY_SIZE];
            for (int i = 0; i < this.LIST_MGR_ID_INDEX_ARRAY_SIZE; i++)
            {
                EntryTableArray[i] = null;
            }

            this.debug(true, "ListMgrClass", "init");

        }

        private int AllocEntryId()
        {
            if (this.GlobalEntryId >= this.LIST_MGR_MAX_GLOBAL_LIST_ID)
            {
                this.GlobalEntryId = 0;
            }
            this.GlobalEntryId++;
            return this.GlobalEntryId;
        }

        private void debug(bool on_off_val, string str0_val, string str1_val)
        {
            if (on_off_val)
                this.logit(str0_val, str1_val);
        }

        private void logit(string str0_val, string str1_val)
        {
            //char s[LOGIT_BUF_SIZE];
            //sprintf(s, "%s(%s)::%s", this->objectName(), this->theCallerName, str0_val);
            //phwangLogit(s, str1_val);

        }

        private void abend(string str0_val, string str1_val)
        {
            //char s[LOGIT_BUF_SIZE];
            //sprintf(s, "%s(%s)::%s", this->objectName(), this->theCallerName, str0_val);
            //phwangAbend(s, str1_val);

        }
    }
}
