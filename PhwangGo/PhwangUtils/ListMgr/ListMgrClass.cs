using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.PhwangUtils
{
    public class ListMgrClass
    {
        private int LIST_MGR_ID_INDEX_ARRAY_SIZE { get; }
        private int LIST_MGR_MAX_GLOBAL_LIST_ID { get; }
        private string ObjectName { get; }
        private string theCallerName { get; }
        private int IdSize { get; }
        private int IndexSize { get; }
        //int theIdIndexSize;
        private int GlobalEntryId { get; set; }
        int MaxIdIndexTableIndex { get; set; }
        private int MaxIndex { get; set; }
        int EntryCount { get; set; }
        private ListEntryClass[] EntryTableArray;
        //pthread_mutex_t theMutex;

        public ListMgrClass(string caller_name_val, int id_size_val, int index_size_val, int global_entry_id_val)
        {
            this.LIST_MGR_MAX_GLOBAL_LIST_ID = 9999;
            this.LIST_MGR_ID_INDEX_ARRAY_SIZE = 1000;
            this.ObjectName = "ListMgrClass";

            this.theCallerName = caller_name_val;
            this.IdSize = id_size_val;
            this.IndexSize = index_size_val;
            this.GlobalEntryId = global_entry_id_val;
            this.EntryCount = 0;
            this.MaxIdIndexTableIndex = 0;
            this.MaxIndex = 0;

            //this->theMutex = PTHREAD_MUTEX_INITIALIZER;

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

        private int AllocEntryIndex()
        {
            for (int i = 0; i < this.LIST_MGR_ID_INDEX_ARRAY_SIZE; i++)
            {
                if (this.EntryTableArray[i] == null)
                {
                    if (i > this.MaxIndex)
                    {
                        this.MaxIndex = i;
                    }
                    this.EntryCount++;
                    return i;
                }
            }

            this.abend("allocEntryIndex", "out of entry_index");
            return -1;
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
