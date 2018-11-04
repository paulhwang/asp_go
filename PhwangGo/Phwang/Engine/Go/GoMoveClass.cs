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
    public class GoMoveClass
    {
        private string objectName = "GoMoveClass";

        private int xX { get; set; }
        private int yY { get; set; }
        private int myColor { get; set; }
        private int turnIndex { get; set; }
        private string moveInfo { get; set; }

        public int XX() { return this.xX; }
        public int YY() { return this.yY; }
        public int MyColor() { return this.myColor; }
        public int TurnIndex() { return this.turnIndex; }
        public string MoveInfo() { return this.moveInfo; }

        public GoMoveClass(string encoded_move_val)
        {
            this.decodeMove(encoded_move_val);
        }

        private void decodeMove(string encoded_move_val)
        {
            this.xX = (encoded_move_val[0] - '0') * 10 + (encoded_move_val[1] - '0');
            this.yY = (encoded_move_val[2] - '0') * 10 + (encoded_move_val[3] - '0');
            this.myColor = encoded_move_val[4] - '0';
            this.turnIndex = (encoded_move_val[5] - '0') * 100 + (encoded_move_val[6] - '0') * 10 + (encoded_move_val[7] - '0');
            this.moveInfo = "(" + this.xX + ", " + this.yY + ") " + this.myColor + ", " + this.turnIndex;
        }
    }
}
