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

namespace Phwang.Go
{
    public class GoFightClass
    {
        private string objectName = "GoFightClass";
        private const int GO_FIGHT_CLASS_GROUP_LIST_ARRAY_SIZE = 7;

        private GoRootClass goRootObject { get; }
        private bool abendEngineOn { get; }
        GoGroupListClass[] groupListArray;
        string theCaptureCount;
        string theLastDeadStone;////////////////to be removed

        public GoFightClass(GoRootClass go_root_object_val)
        {
            this.goRootObject = go_root_object_val;
            this.groupListArray = new GoGroupListClass[GO_FIGHT_CLASS_GROUP_LIST_ARRAY_SIZE];

        }

        public void EnterBattle(GoMoveClass move_val)
        {

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
