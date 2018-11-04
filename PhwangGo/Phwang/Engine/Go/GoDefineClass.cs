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
    public class GoDefineClass
    {
        public const int MAX_BOARD_SIZE = 19;

        public const int GO_EMPTY_STONE = 0;
        public const int GO_BLACK_STONE = 1;
        public const int GO_WHITE_STONE = 2;
        public const int GO_MARK_DEAD_STONE_DIFF = 4;
        public const int GO_MARK_EMPTY_STONE_DIFF = 8;

        public const int GO_MARKED_DEAD_BLACK_STONE = (GO_BLACK_STONE + GO_MARK_DEAD_STONE_DIFF);
        public const int GO_MARKED_DEAD_WHITE_STONE = (GO_WHITE_STONE + GO_MARK_DEAD_STONE_DIFF);

        public const int GO_MARKED_EMPTY_BLACK_STONE = (GO_BLACK_STONE + GO_MARK_EMPTY_STONE_DIFF);
        public const int GO_MARKED_EMPTY_WHITE_STONE = (GO_WHITE_STONE + GO_MARK_EMPTY_STONE_DIFF);

        public static int GetOppositeColor(int color_val)
        {
            switch (color_val)
            {
                case GO_BLACK_STONE:
                    return GO_WHITE_STONE;

                case GO_WHITE_STONE:
                    return GO_BLACK_STONE;

                default:
                    return GO_EMPTY_STONE;
            }
        }

        public static bool isNeighborStone(int x1_val, int y1_val, int x2_val, int y2_val)
        {
            if (x1_val == x2_val)
            {
                if ((y1_val + 1 == y2_val) || (y1_val - 1 == y2_val))
                {
                    return true;
                }
            }
            if (y1_val == y2_val)
            {
                if ((x1_val + 1 == x2_val) || (x1_val - 1 == x2_val))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
