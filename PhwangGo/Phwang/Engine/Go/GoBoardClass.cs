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
    public class GoBoardClass
    {
        private string objectName = "GoBoardClass";

        private int[,] boardArray { get; }
        private int[,] markedBoardArray { get; }
        //char theBoardOutputBuffer[1 + 3 + 1 + 19 * 19 + 3 * 2 + 2 * 2 + 32];
        int blackCapturedStones { get; set; }
        int whiteCapturedStones { get; set; }
        int lastDeadX { get; set; }
        int lastDeadY { get; set; }

        private GoRootClass rootObject { get; }

        public GoBoardClass(GoRootClass root_object_val)
        {
            this.rootObject = root_object_val;

            this.boardArray = new int[19,19];
            this.markedBoardArray = new int[19, 19];
            this.ClearLastDeadStone();
        }

        private bool isEmptySpace(int x_val, int y_val)
        {
            if (!this.rootObject.ConfigObject().IsValidCoordinates(x_val, y_val))
            {
                return false;
            }
            if (this.boardArray[x_val, y_val] != GoDefineClass.GO_EMPTY_STONE)
            {
                return false;
            }
            return true;
        }
        public void ClearLastDeadStone()
        {
            this.lastDeadX = 19;
            this.lastDeadY = 19;
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
