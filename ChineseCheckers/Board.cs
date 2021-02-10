using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers
{
    public class Board
    {
        public const int EMPTY_VALUE = 0;
        public const int VOID_VALUE = -1;
        public int Empty
        {
            get { return EMPTY_VALUE; }
        }

        public int Void
        {
            get { return VOID_VALUE; }
        }
        private readonly int[][] board;
        private static readonly List<Coordinate> TOP_PIECES;
        private static readonly List<Coordinate> TOP_RIGHT_PIECES;
        private static readonly List<Coordinate> BOTTOM_RIGHT_PIECES;
        private static readonly List<Coordinate> BOTTOM_PIECES;
        private static readonly List<Coordinate> BOTTOM_LEFT_PIECES;
        private static readonly List<Coordinate> TOP_LEFT_PIECES;

        static Board()
        {
            TOP_PIECES = new List<Coordinate>();
            TOP_PIECES.Add(new Coordinate(0, 6));
            TOP_PIECES.Add(new Coordinate(1, 5));
            TOP_PIECES.Add(new Coordinate(1, 6));
            TOP_PIECES.Add(new Coordinate(2, 5));
            TOP_PIECES.Add(new Coordinate(2, 6));
            TOP_PIECES.Add(new Coordinate(2, 7));
            TOP_PIECES.Add(new Coordinate(3, 4));
            TOP_PIECES.Add(new Coordinate(3, 5));
            TOP_PIECES.Add(new Coordinate(3, 6));
            TOP_PIECES.Add(new Coordinate(3, 7));

            TOP_RIGHT_PIECES = new List<Coordinate>();
            TOP_RIGHT_PIECES.Add(new Coordinate(4, 12));
            TOP_RIGHT_PIECES.Add(new Coordinate(4, 11));
            TOP_RIGHT_PIECES.Add(new Coordinate(5, 11));
            TOP_RIGHT_PIECES.Add(new Coordinate(4, 10));
            TOP_RIGHT_PIECES.Add(new Coordinate(5, 10));
            TOP_RIGHT_PIECES.Add(new Coordinate(6, 11));
            TOP_RIGHT_PIECES.Add(new Coordinate(4, 9));
            TOP_RIGHT_PIECES.Add(new Coordinate(5, 9));
            TOP_RIGHT_PIECES.Add(new Coordinate(6, 10));
            TOP_RIGHT_PIECES.Add(new Coordinate(7, 10));

            BOTTOM_RIGHT_PIECES = new List<Coordinate>();
            BOTTOM_RIGHT_PIECES.Add(new Coordinate(12, 12));
            BOTTOM_RIGHT_PIECES.Add(new Coordinate(11, 11));
            BOTTOM_RIGHT_PIECES.Add(new Coordinate(12, 11));
            BOTTOM_RIGHT_PIECES.Add(new Coordinate(10, 11));
            BOTTOM_RIGHT_PIECES.Add(new Coordinate(11, 10));
            BOTTOM_RIGHT_PIECES.Add(new Coordinate(12, 10));
            BOTTOM_RIGHT_PIECES.Add(new Coordinate(9, 10));
            BOTTOM_RIGHT_PIECES.Add(new Coordinate(10, 10));
            BOTTOM_RIGHT_PIECES.Add(new Coordinate(11, 9));
            BOTTOM_RIGHT_PIECES.Add(new Coordinate(12, 9));

            BOTTOM_PIECES = new List<Coordinate>();
            BOTTOM_PIECES.Add(new Coordinate(16, 6));
            BOTTOM_PIECES.Add(new Coordinate(15, 5));
            BOTTOM_PIECES.Add(new Coordinate(15, 6));
            BOTTOM_PIECES.Add(new Coordinate(14, 5));
            BOTTOM_PIECES.Add(new Coordinate(14, 6));
            BOTTOM_PIECES.Add(new Coordinate(14, 7));
            BOTTOM_PIECES.Add(new Coordinate(13, 4));
            BOTTOM_PIECES.Add(new Coordinate(13, 5));
            BOTTOM_PIECES.Add(new Coordinate(13, 6));
            BOTTOM_PIECES.Add(new Coordinate(13, 7));

            BOTTOM_LEFT_PIECES = new List<Coordinate>();
            BOTTOM_LEFT_PIECES.Add(new Coordinate(12, 0));
            BOTTOM_LEFT_PIECES.Add(new Coordinate(11, 0));
            BOTTOM_LEFT_PIECES.Add(new Coordinate(12, 1));
            BOTTOM_LEFT_PIECES.Add(new Coordinate(10, 1));
            BOTTOM_LEFT_PIECES.Add(new Coordinate(11, 1));
            BOTTOM_LEFT_PIECES.Add(new Coordinate(12, 2));
            BOTTOM_LEFT_PIECES.Add(new Coordinate(9, 1));
            BOTTOM_LEFT_PIECES.Add(new Coordinate(10, 2));
            BOTTOM_LEFT_PIECES.Add(new Coordinate(11, 2));
            BOTTOM_LEFT_PIECES.Add(new Coordinate(12, 3));

            TOP_LEFT_PIECES = new List<Coordinate>();
            TOP_LEFT_PIECES.Add(new Coordinate(4, 0));
            TOP_LEFT_PIECES.Add(new Coordinate(4, 1));
            TOP_LEFT_PIECES.Add(new Coordinate(5, 0));
            TOP_LEFT_PIECES.Add(new Coordinate(4, 2));
            TOP_LEFT_PIECES.Add(new Coordinate(5, 1));
            TOP_LEFT_PIECES.Add(new Coordinate(6, 1));
            TOP_LEFT_PIECES.Add(new Coordinate(4, 3));
            TOP_LEFT_PIECES.Add(new Coordinate(5, 2));
            TOP_LEFT_PIECES.Add(new Coordinate(6, 2));
            TOP_LEFT_PIECES.Add(new Coordinate(7, 1));
        }
        public Board(Player[] players)
        {
            switch (players.Length)
            {
                case 2:
                    players[0].StartCoordinates = TOP_PIECES;
                    players[0].GoalCoordinates = BOTTOM_PIECES;
                    players[1].StartCoordinates = BOTTOM_PIECES;
                    players[1].GoalCoordinates = TOP_PIECES;
                    board = new int[][]
                    {
                        new int[] {-1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1},
                        new int[] {-1,-1,-1,-1,-1,1,1,-1,-1,-1,-1,-1,-1},
                        new int[] {-1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1},
                        new int[] {-1,-1,-1,-1,1,1,1,1,-1,-1,-1,-1,-1},
                        new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0},
                        new int[] {0,0,0,0,0,0,0,0,0,0,0,0,-1},
                        new int[] {-1,0,0,0,0,0,0,0,0,0,0,0,-1},
                        new int[] {-1,0,0,0,0,0,0,0,0,0,0,-1,-1},
                        new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
                        new int[] {-1,0,0,0,0,0,0,0,0,0,0,-1,-1},
                        new int[] {-1,0,0,0,0,0,0,0,0,0,0,0,-1},
                        new int[] {0,0,0,0,0,0,0,0,0,0,0,0,-1},
                        new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0},
                        new int[] {-1,-1,-1,-1,2,2,2,2,-1,-1,-1,-1,-1},
                        new int[] {-1,-1,-1,-1,-1,2,2,2,-1,-1,-1,-1,-1},
                        new int[] {-1,-1,-1,-1,-1,2,2,-1,-1,-1,-1,-1,-1},
                        new int[] {-1,-1,-1,-1,-1,-1,2,-1,-1,-1,-1,-1,-1}
                        //new int[] {-1,-1,-1,-1,-1,-1,2,-1,-1,-1,-1,-1,-1},
                        //new int[] {-1,-1,-1,-1,-1,2,2,-1,-1,-1,-1,-1,-1},
                        //new int[] {-1,-1,-1,-1,-1,2,2,2,-1,-1,-1,-1,-1},
                        //new int[] {-1,-1,-1,-1,2,2,2,0,-1,-1,-1,-1,-1},
                        //new int[] {0,0,0,0,0,0,0,0,0,2,0,0,0},
                        //new int[] {0,0,0,0,0,0,0,0,0,0,0,0,-1},
                        //new int[] {-1,0,0,0,0,0,0,0,0,0,0,0,-1},
                        //new int[] {-1,0,0,0,0,0,0,0,0,0,0,-1,-1},
                        //new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
                        //new int[] {-1,0,0,0,0,0,0,0,0,0,0,-1,-1},
                        //new int[] {-1,0,0,0,0,0,0,0,0,0,0,0,-1},
                        //new int[] {0,0,0,0,0,0,0,0,0,0,0,0,-1},
                        //new int[] {0,0,0,0,0,0,0,1,0,0,0,0,0},
                        //new int[] {-1,-1,-1,-1,0,1,1,1,-1,-1,-1,-1,-1},
                        //new int[] {-1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1},
                        //new int[] {-1,-1,-1,-1,-1,1,1,-1,-1,-1,-1,-1,-1},
                        //new int[] {-1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1}
                    };
                    break;
                case 3:
                    players[0].StartCoordinates = TOP_PIECES;
                    players[0].GoalCoordinates = BOTTOM_PIECES;
                    players[1].StartCoordinates = BOTTOM_RIGHT_PIECES;
                    players[1].GoalCoordinates = TOP_LEFT_PIECES;
                    players[2].StartCoordinates = BOTTOM_LEFT_PIECES;
                    players[2].GoalCoordinates = TOP_RIGHT_PIECES;
                    board = new int[][]
                    {
                        new int[] { -1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,1,1,-1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,1,1,1,1,-1,-1,-1,-1,-1},
                        new int[]{ 0,0,0,0,0,0,0,0,0,0,0,0,0},
                        new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,-1},
                        new int[]{ -1,0,0,0,0,0,0,0,0,0,0,0,-1},
                        new int[] { -1,0,0,0,0,0,0,0,0,0,0,-1,-1},
                        new int[]{ -1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
                        new int[] { -1,3,0,0,0,0,0,0,0,0,2,-1,-1},
                        new int[]{ -1,3,3,0,0,0,0,0,0,0,2,2,-1},
                        new int[] { 3,3,3,0,0,0,0,0,0,2,2,2,-1},
                        new int[]{ 3,3,3,3,0,0,0,0,0,2,2,2,2},
                        new int[] { -1,-1,-1,-1,0,0,0,0,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,0,0,0,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,0,0,-1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1}
                    };
                    break;
                case 4:
                    players[0].StartCoordinates = TOP_LEFT_PIECES;
                    players[0].GoalCoordinates = BOTTOM_RIGHT_PIECES;
                    players[1].StartCoordinates = TOP_RIGHT_PIECES;
                    players[1].GoalCoordinates = BOTTOM_LEFT_PIECES;
                    players[2].StartCoordinates = BOTTOM_RIGHT_PIECES;
                    players[2].GoalCoordinates = TOP_LEFT_PIECES;
                    players[3].StartCoordinates = BOTTOM_LEFT_PIECES;
                    players[3].GoalCoordinates = TOP_RIGHT_PIECES;
                    board = new int[][]
                    {
                        new int[] { -1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,0,0,-1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,0,0,0,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,0,0,0,0,-1,-1,-1,-1,-1},
                        new int[]{ 1,1,1,1,0,0,0,0,0,2,2,2,2},
                        new int[] { 1,1,1,0,0,0,0,0,0,2,2,2,-1},
                        new int[]{ -1,1,1,0,0,0,0,0,0,0,2,2,-1},
                        new int[] { -1,1,0,0,0,0,0,0,0,0,2,-1,-1},
                        new int[]{ -1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
                        new int[] { -1,4,0,0,0,0,0,0,0,0,3,-1,-1},
                        new int[]{ -1,4,4,0,0,0,0,0,0,0,3,3,-1},
                        new int[] { 4,4,4,0,0,0,0,0,0,3,3,3,-1},
                        new int[]{ 4,4,4,4,0,0,0,0,0,3,3,3,3},
                        new int[] { -1,-1,-1,-1,0,0,0,0,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,0,0,0,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,0,0,-1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1}
                    };
                    break;
                case 5:
                    players[0].StartCoordinates = TOP_PIECES;
                    players[0].GoalCoordinates = BOTTOM_PIECES;
                    players[1].StartCoordinates = TOP_RIGHT_PIECES;
                    players[1].GoalCoordinates = BOTTOM_LEFT_PIECES;
                    players[2].StartCoordinates = BOTTOM_RIGHT_PIECES;
                    players[2].GoalCoordinates = TOP_LEFT_PIECES;
                    players[3].StartCoordinates = BOTTOM_PIECES;
                    players[3].GoalCoordinates = TOP_PIECES;
                    players[4].StartCoordinates = BOTTOM_LEFT_PIECES;
                    players[4].GoalCoordinates = TOP_RIGHT_PIECES;
                    board = new int[][]
                    {
                        new int[] { -1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,1,1,-1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,1,1,1,1,-1,-1,-1,-1,-1},
                        new int[]{ 0,0,0,0,0,0,0,0,0,2,2,2,2},
                        new int[] { 0,0,0,0,0,0,0,0,0,2,2,2,-1},
                        new int[]{ -1,0,0,0,0,0,0,0,0,0,2,2,-1},
                        new int[] { -1,0,0,0,0,0,0,0,0,0,2,-1,-1},
                        new int[]{ -1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
                        new int[] { -1,5,0,0,0,0,0,0,0,0,3,-1,-1},
                        new int[]{ -1,5,5,0,0,0,0,0,0,0,3,3,-1},
                        new int[] { 5,5,5,0,0,0,0,0,0,3,3,3,-1},
                        new int[]{ 5,5,5,5,0,0,0,0,0,3,3,3,3},
                        new int[] { -1,-1,-1,-1,4,4,4,4,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,4,4,4,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,4,4,-1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,-1,4,-1,-1,-1,-1,-1,-1}
                    };
                    break;
                case 6:
                    players[0].StartCoordinates = TOP_PIECES;
                    players[0].GoalCoordinates = BOTTOM_PIECES;
                    players[1].StartCoordinates = TOP_RIGHT_PIECES;
                    players[1].GoalCoordinates = BOTTOM_LEFT_PIECES;
                    players[2].StartCoordinates = BOTTOM_RIGHT_PIECES;
                    players[2].GoalCoordinates = TOP_LEFT_PIECES;
                    players[3].StartCoordinates = BOTTOM_PIECES;
                    players[3].GoalCoordinates = TOP_PIECES;
                    players[4].StartCoordinates = BOTTOM_LEFT_PIECES;
                    players[4].GoalCoordinates = TOP_RIGHT_PIECES;
                    players[5].StartCoordinates = TOP_LEFT_PIECES;
                    players[5].GoalCoordinates = BOTTOM_RIGHT_PIECES;
                    board = new int[][] {
                        new int[] { -1,-1,-1,-1,-1,-1,1,-1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,1,1,-1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,1,1,1,1,-1,-1,-1,-1,-1},
                        new int[]{ 6,6,6,6,0,0,0,0,0,2,2,2,2},
                        new int[] { 6,6,6,0,0,0,0,0,0,2,2,2,-1},
                        new int[]{ -1,6,6,0,0,0,0,0,0,0,2,2,-1},
                        new int[] { -1,6,0,0,0,0,0,0,0,0,2,-1,-1},
                        new int[]{ -1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
                        new int[] { -1,5,0,0,0,0,0,0,0,0,3,-1,-1},
                        new int[]{ -1,5,5,0,0,0,0,0,0,0,3,3,-1},
                        new int[] { 5,5,5,0,0,0,0,0,0,3,3,3,-1},
                        new int[]{ 5,5,5,5,0,0,0,0,0,3,3,3,3},
                        new int[] { -1,-1,-1,-1,4,4,4,4,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,4,4,4,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,4,4,-1,-1,-1,-1,-1,-1},
                        new int[]{ -1,-1,-1,-1,-1,-1,4,-1,-1,-1,-1,-1,-1}
                    };
                    break;
            }
        }

        public string GetBoardStr(Coordinate highlight1, Coordinate highlight2)
        {
            StringBuilder sb = new StringBuilder();
            bool shouldHighlight = highlight1 != null && highlight2 != null;
            for (int i = 0; i < board.Count(); i++)
            {
                if (i % 2 != 0)
                {
                    sb.Append("    ");
                }
                for (int j = 0; j < board[0].Count(); j++)
                {
                    if (board[i][j] != VOID_VALUE)
                        if (shouldHighlight && (
                            (i == highlight1.i && j == highlight1.j)
                            || (i == highlight2.i && j == highlight2.j)))
                            sb.Append($"*{(char)(board[i][j] == 0 ? ' ' : ('0' + board[i][j]))}{GetCharFromIndex(i)}{GetCharFromIndex(j)}");
                        else
                            sb.Append($" {(char)(board[i][j] == 0 ? ' ' : ('0' + board[i][j]))}{GetCharFromIndex(i)}{GetCharFromIndex(j)}");
                    //sb.Append($"{board[i][j]}{i},{j}");
                    else
                        sb.Append("    ");
                    if (j < board[0].Count() - 1)
                        sb.Append("    ");
                }
                if (i < board.Count() - 1)
                    sb.AppendLine();
            }
            return sb.ToString();
        }

        public Coordinate GetCoordinateFromChars(char a, char b)
        {
            int i = GetIndexFromChar(a);
            int j = GetIndexFromChar(b);
            return GetCoordinateFromIndex(i, j);
        }

        public Coordinate GetCoordinateFromIndex(int i, int j)
        {
            ValidateCoordinate(i, j);
            return new Coordinate(i, j);
        }

        public int GetValueFromChars(char a, char b)
        {
            int i = GetIndexFromChar(a);
            int j = GetIndexFromChar(b);
            return GetValueFromIndex(i, j);
        }

        public int GetValueFromIndex(int i, int j)
        {
            ValidateCoordinate(i, j);
            return board[i][j];
        }

        public bool IsOccupied(int i, int j)
        {
            int v = GetValueFromIndex(i, j);
            if (v != Empty && v != Void)
                return true;
            else
                return false;
        }

        public char GetCharFromIndex(int i)
        {
            if (i >= 0 && i <= 9)
                return (char)(i + '0');
            else if (i >= 10 && i <= 35)
                return (char)(i - 10 + 'A');
            else
                throw new ArgumentOutOfRangeException("i", i, $"Invalid value for argument i: {i}");
        }
        public int GetIndexFromChar(char c)
        {
            if (c >= '0' && c <= '9')
                return c - '0';
            else if (c >= 'A' && c <= 'Z')
                return c - 'A' + 10;
            else
                throw new ArgumentOutOfRangeException("c", c, $"Invalid value for argument c: {c}");
        }

        public bool IsPlayer(int i, int j, Player player)
        {
            ValidateCoordinate(i, j);
            bool result = false;
            if (board[i][j] == player.Id) result = true;
            return result;
        }

        public List<Coordinate> GetAvailableMoves(Coordinate c)
        {
            ValidateCoordinate(c.i, c.j);
            var list = new List<Coordinate>();
            Coordinate tmp = null;
            if ((tmp = Movement.GetLeftMove(this, c)) != null) list.Add(tmp);
            if ((tmp = Movement.GetRightMove(this, c)) != null) list.Add(tmp);
            if ((tmp = Movement.GetUpLeftMove(this, c)) != null) list.Add(tmp);
            if ((tmp = Movement.GetUpRightMove(this, c)) != null) list.Add(tmp);
            if ((tmp = Movement.GetDownLeftMove(this, c)) != null) list.Add(tmp);
            if ((tmp = Movement.GetDownRightMove(this, c)) != null) list.Add(tmp);
            GetAvailableJumpMoves(c, list);
            return list;
        }

        public void GetAvailableJumpMoves(Coordinate c, List<Coordinate> list)
        {
            ValidateCoordinate(c.i, c.j);
            Coordinate tmp = null;
            if ((tmp = Movement.GetLeftJumpMove(this, c)) != null && !list.Contains(tmp))
            {
                list.Add(tmp);
                GetAvailableJumpMoves(tmp, list);
            }
            if ((tmp = Movement.GetRightJumpMove(this, c)) != null && !list.Contains(tmp))
            {
                list.Add(tmp);
                GetAvailableJumpMoves(tmp, list);
            }
            if ((tmp = Movement.GetUpLeftJumpMove(this, c)) != null && !list.Contains(tmp))
            {
                list.Add(tmp);
                GetAvailableJumpMoves(tmp, list);
            }
            if ((tmp = Movement.GetUpRightJumpMove(this, c)) != null && !list.Contains(tmp))
            {
                list.Add(tmp);
                GetAvailableJumpMoves(tmp, list);
            }
            if ((tmp = Movement.GetDownLeftJumpMove(this, c)) != null && !list.Contains(tmp))
            {
                list.Add(tmp);
                GetAvailableJumpMoves(tmp, list);
            }
            if ((tmp = Movement.GetDownRightJumpMove(this, c)) != null && !list.Contains(tmp))
            {
                list.Add(tmp);
                GetAvailableJumpMoves(tmp, list);
            }
        }

        private void ValidateCoordinate(int i, int j)
        {
            if (i < 0 || i >= board.Length)
                throw new ArgumentOutOfRangeException("i", i, $"Invalid value for argument i: {i}");
            if (j < 0 || j >= board[i].Length)
                throw new ArgumentOutOfRangeException("j", j, $"Invalid value for argument j: {j}");
        }

        public void PerformMove(Coordinate from, Coordinate to)
        {
            ValidateCoordinate(from.i, from.j);
            ValidateCoordinate(to.i, to.j);
            var temp = board[from.i][from.j];
            board[from.i][from.j] = board[to.i][to.j];
            board[to.i][to.j] = temp;
        }

        public bool PlayerHasWon(Player player)
        {
            bool result = true;
            foreach(Coordinate c in player.GoalCoordinates)
            {
                if (GetValueFromIndex(c.i, c.j) != player.Id)
                    result = false;
            }
            return result;
        }
    }
}
