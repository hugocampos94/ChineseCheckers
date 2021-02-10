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
            if (c.j - 1 >= 0 && board.GetValueFromIndex(c.i,c.j - 1) == board.Empty)
                return new Coordinate(c.i, c.j - 1);
            return null;
        }

        public static Coordinate GetRightMove(Board board, Coordinate c)
        {
            if (c.j + 1 <= 12 && board.GetValueFromIndex(c.i,c.j + 1) == board.Empty)
                return new Coordinate(c.i, c.j + 1);
            return null;
        }

        public static Coordinate GetUpLeftMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.i % 2 == 0)
                jOffset = -1;

            if (c.i - 1 >= 0 && c.j + jOffset >= 0
                && board.GetValueFromIndex(c.i - 1,c.j + jOffset) == board.Empty)
                return new Coordinate(c.i - 1, c.j + jOffset);
            return null;
        }

        public static Coordinate GetUpRightMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.i % 2 != 0)
                jOffset = 1;

            if (c.i - 1 >= 0 && c.j + jOffset <= 12
                && board.GetValueFromIndex(c.i - 1,c.j + jOffset) == board.Empty)
                return new Coordinate(c.i - 1, c.j + jOffset);
            return null;
        }

        public static Coordinate GetDownLeftMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.i % 2 == 0)
                jOffset = -1;

            if (c.i + 1 <= 16 && c.j + jOffset >= 0
                && board.GetValueFromIndex(c.i + 1,c.j + jOffset) == board.Empty)
                return new Coordinate(c.i + 1, c.j + jOffset);
            return null;
        }

        public static Coordinate GetDownRightMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.i % 2 != 0)
                jOffset = 1;

            if (c.i + 1 <= 16 && c.j + jOffset <= 12
                && board.GetValueFromIndex(c.i + 1,c.j + jOffset) == board.Empty)
                return new Coordinate(c.i + 1, c.j + jOffset);
            return null;
        }

        public static Coordinate GetLeftJumpMove(Board board, Coordinate c)
        {
            if (c.j - 2 >= 0 && board.GetValueFromIndex(c.i,c.j - 2) == board.Empty && board.IsOccupied(c.i, c.j - 1))
                return new Coordinate(c.i, c.j - 2);
            return null;
        }

        public static Coordinate GetRightJumpMove(Board board, Coordinate c)
        {
            if (c.j + 2 <= 12 && board.GetValueFromIndex(c.i,c.j + 2) == board.Empty && board.IsOccupied(c.i, c.j + 1))
                return new Coordinate(c.i, c.j + 2);
            return null;
        }

        public static Coordinate GetUpLeftJumpMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.i % 2 == 0)
                jOffset = -1;

            if (c.i - 2 >= 0 && c.j - 1 >= 0
                && board.GetValueFromIndex(c.i - 2,c.j - 1) == board.Empty && board.IsOccupied(c.i - 1, c.j + jOffset))
                return new Coordinate(c.i - 2, c.j - 1);
            return null;
        }
        public static Coordinate GetUpRightJumpMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.i % 2 != 0)
                jOffset = 1;

            if (c.i - 2 >= 0 && c.j + 1 <= 12
                && board.GetValueFromIndex(c.i - 2,c.j + 1) == board.Empty && board.IsOccupied(c.i - 1, c.j + jOffset))
                return new Coordinate(c.i - 2, c.j + 1);
            return null;
        }
        public static Coordinate GetDownLeftJumpMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.i % 2 == 0)
                jOffset = -1;

            if (c.i + 2 <= 16 && c.j - 1 >= 0
                && board.GetValueFromIndex(c.i + 2,c.j - 1) == board.Empty && board.IsOccupied(c.i + 1, c.j + jOffset))
                return new Coordinate(c.i + 2, c.j - 1);
            return null;
        }
        public static Coordinate GetDownRightJumpMove(Board board, Coordinate c)
        {
            int jOffset = 0;
            if (c.i % 2 != 0)
                jOffset = 1;

            if (c.i + 2 <= 16 && c.j + 1 <= 12
                && board.GetValueFromIndex(c.i + 2,c.j + 1) == board.Empty && board.IsOccupied(c.i + 1, c.j + jOffset))
                return new Coordinate(c.i + 2, c.j + 1);
            return null;
        }
    }
}
