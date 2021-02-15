using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers
{
    public static class Movement
    {
        public static Coordinate GetLeftMove(Board board, Coordinate c)
        {
            if (c.jInt - 1 >= 0 && board.GetValueFromIndex(c.iInt,c.jInt - 1) == board.Empty)
                return new Coordinate(c.iInt, c.jInt - 1);
            return null;
        }

        public static Coordinate GetRightMove(Board board, Coordinate c)
        {
            if (c.jInt + 1 <= 12 && board.GetValueFromIndex(c.iInt,c.jInt + 1) == board.Empty)
                return new Coordinate(c.iInt, c.jInt + 1);
            return null;
        }

        public static Coordinate GetUpLeftMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.iInt % 2 == 0)
                jOffset = -1;

            if (c.iInt - 1 >= 0 && c.jInt + jOffset >= 0
                && board.GetValueFromIndex(c.iInt - 1,c.jInt + jOffset) == board.Empty)
                return new Coordinate(c.iInt - 1, c.jInt + jOffset);
            return null;
        }

        public static Coordinate GetUpRightMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.iInt % 2 != 0)
                jOffset = 1;

            if (c.iInt - 1 >= 0 && c.jInt + jOffset <= 12
                && board.GetValueFromIndex(c.iInt - 1,c.jInt + jOffset) == board.Empty)
                return new Coordinate(c.iInt - 1, c.jInt + jOffset);
            return null;
        }

        public static Coordinate GetDownLeftMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.iInt % 2 == 0)
                jOffset = -1;

            if (c.iInt + 1 <= 16 && c.jInt + jOffset >= 0
                && board.GetValueFromIndex(c.iInt + 1,c.jInt + jOffset) == board.Empty)
                return new Coordinate(c.iInt + 1, c.jInt + jOffset);
            return null;
        }

        public static Coordinate GetDownRightMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.iInt % 2 != 0)
                jOffset = 1;

            if (c.iInt + 1 <= 16 && c.jInt + jOffset <= 12
                && board.GetValueFromIndex(c.iInt + 1,c.jInt + jOffset) == board.Empty)
                return new Coordinate(c.iInt + 1, c.jInt + jOffset);
            return null;
        }

        public static Coordinate GetLeftJumpMove(Board board, Coordinate c)
        {
            if (c.jInt - 2 >= 0 && board.GetValueFromIndex(c.iInt,c.jInt - 2) == board.Empty && board.IsOccupied(c.iInt, c.jInt - 1))
                return new Coordinate(c.iInt, c.jInt - 2);
            return null;
        }

        public static Coordinate GetRightJumpMove(Board board, Coordinate c)
        {
            if (c.jInt + 2 <= 12 && board.GetValueFromIndex(c.iInt,c.jInt + 2) == board.Empty && board.IsOccupied(c.iInt, c.jInt + 1))
                return new Coordinate(c.iInt, c.jInt + 2);
            return null;
        }

        public static Coordinate GetUpLeftJumpMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.iInt % 2 == 0)
                jOffset = -1;

            if (c.iInt - 2 >= 0 && c.jInt - 1 >= 0
                && board.GetValueFromIndex(c.iInt - 2,c.jInt - 1) == board.Empty && board.IsOccupied(c.iInt - 1, c.jInt + jOffset))
                return new Coordinate(c.iInt - 2, c.jInt - 1);
            return null;
        }
        public static Coordinate GetUpRightJumpMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.iInt % 2 != 0)
                jOffset = 1;

            if (c.iInt - 2 >= 0 && c.jInt + 1 <= 12
                && board.GetValueFromIndex(c.iInt - 2,c.jInt + 1) == board.Empty && board.IsOccupied(c.iInt - 1, c.jInt + jOffset))
                return new Coordinate(c.iInt - 2, c.jInt + 1);
            return null;
        }
        public static Coordinate GetDownLeftJumpMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.iInt % 2 == 0)
                jOffset = -1;

            if (c.iInt + 2 <= 16 && c.jInt - 1 >= 0
                && board.GetValueFromIndex(c.iInt + 2,c.jInt - 1) == board.Empty && board.IsOccupied(c.iInt + 1, c.jInt + jOffset))
                return new Coordinate(c.iInt + 2, c.jInt - 1);
            return null;
        }
        public static Coordinate GetDownRightJumpMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.iInt % 2 != 0)
                jOffset = 1;

            if (c.iInt + 2 <= 16 && c.jInt + 1 <= 12
                && board.GetValueFromIndex(c.iInt + 2,c.jInt + 1) == board.Empty && board.IsOccupied(c.iInt + 1, c.jInt + jOffset))
                return new Coordinate(c.iInt + 2, c.jInt + 1);
            return null;
        }
    }
}
