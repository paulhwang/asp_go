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
    public class GoGroupClass
    {
        private string objectName = "GoGroupClass";
        GoGroupListClass groupListObject;
        private int maxX { get; set; }
        private int minX { get; set; }
        private int maxY { get; set; }
        private int minY { get; set; }
        //int theDeadMatrix[19][19];
        int theIndexNumber;
        int stoneCount;
        int theMyColor;
        int hisColor { get; set; }
        private bool[,] existMatrix { get; }

        public int HisColor() { return this.hisColor; }
        public int StoneCount() { return this.stoneCount; }
        public bool ExistMatrix(int x_val, int y_val) { return this.existMatrix[x_val, y_val]; }


        public GoGroupClass(GoGroupListClass group_list_object_val)
        {
            this.groupListObject = group_list_object_val;
            this.existMatrix = new bool[GoDefineClass.MAX_BOARD_SIZE, GoDefineClass.MAX_BOARD_SIZE];
        }

        public bool GroupHasAir()
        {
            int i = this.minX;
            while (i <= this.maxX)
            {
                int j = this.minY;
                while (j <= this.maxY)
                {
                    if (this.existMatrix[i, j])
                    {
                        if (this.groupListObject.FightObject().RootObject().BoardObject().StoneHasAir(i, j))
                        {
                            return true;
                        }
                    }
                    j += 1;
                }
                i += 1;
            }
            return false;
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
