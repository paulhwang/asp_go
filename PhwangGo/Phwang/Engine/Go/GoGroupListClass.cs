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
    public class GoGroupListClass
    {
        private string objectName = "GoGroupListClass";
        private const int GO_GROUP_LIST_CLASS_GROUP_ARRAY_SIZE = 400;

        private GoFightClass fightObject { get; }
        private int indexNumber { get; }
        private int myColor { get; }
        int theHisColor;
        private bool isDead { get; }
        private string bigStoneColor { get; }
        private string smallStoneColor { get; }
        private int isMarkedDead { get; }
        private int groupCount { get; }
        private GoGroupClass[] groupArray { get; }

        public GoGroupListClass(GoFightClass fight_object_val,
                       int index_val,
                       int color_val,
                       bool is_dead_val,
                       string big_stone_val,
                       string small_stone_val)
        {
            this.fightObject = fight_object_val;
            this.groupArray = new GoGroupClass[GO_GROUP_LIST_CLASS_GROUP_ARRAY_SIZE];
            this.indexNumber = index_val;
            this.myColor = color_val;
            this.isDead = is_dead_val;
            this.bigStoneColor = big_stone_val;
            this.smallStoneColor = small_stone_val;
            this.groupCount = 0;
            this.isMarkedDead = 0;
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
