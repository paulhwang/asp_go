﻿/*
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

namespace Phwang.FrontEnd
{
    public class FrontEndJobMgrClass
    {
        private string objectName = "FrontEndJobMgrClass";
        private const int MAX_AJAX_ENTRY_ARRAY_SIZE = 1000;

        private FrontEndFabricClass frontEndFabricObject { get; }
        private int maxJobIndex { get; set; }
        private FrontEndJobClass[] jobArray { get; }

        public FrontEndJobMgrClass(FrontEndFabricClass fabric_object_val)
        {
            this.frontEndFabricObject = fabric_object_val;

            this.maxJobIndex = 0;
            this.jobArray = new FrontEndJobClass[MAX_AJAX_ENTRY_ARRAY_SIZE];
        }

        public void PutJobObject(FrontEndJobClass val)
        {
            for (var i = 0; i < this.maxJobIndex; i++)
            {
                if (this.jobArray[i] == null)
                {
                    this.jobArray[i] = val;
                    return;
                }
            }
            this.jobArray[this.maxJobIndex] = val;
            this.incrementMaxAjaxMapIndex();
        }

        public FrontEndJobClass GetJobObject(string ajax_id_str_val)
        {
            int index;

            var found = false;
            for (index = 0; index < this.maxJobIndex; index++)
            {
                if (this.jobArray[index] != null)
                {
                    if (this.jobArray[index].ajaxIdStr == ajax_id_str_val)
                    {
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                this.abendIt("getAjaxEntryObject", "not found" + ajax_id_str_val);
                return null;
            }

            FrontEndJobClass element = this.jobArray[index];
            this.jobArray[index] = null;
            return element;
        }

        private void incrementMaxAjaxMapIndex()
        {
            this.maxJobIndex++;
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
